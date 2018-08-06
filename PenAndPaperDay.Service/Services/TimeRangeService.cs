using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class TimeRangeService : ITimeRangeService
    {
        private readonly ITimeRangeRepository _timeRangeRepository;

        public TimeRangeService(ITimeRangeRepository timeRangeRepository)
        {
            _timeRangeRepository = timeRangeRepository;
        }

        public TimeRangeResultDto SaveTimeRange(TimeRangeResultDto timeRangeResultDto)
        {
            if (timeRangeResultDto == null || timeRangeResultDto.TimeRangeForm == null)
                throw new ArgumentNullException("No TimeRangeForm send");

            if (timeRangeResultDto.TimeRangeForm.From ==null)
                throw new ArgumentNullException("No From send");

            if (timeRangeResultDto.TimeRangeForm.Till == null)
                throw new ArgumentNullException("No Till send");

            if (!DateTime.TryParse(timeRangeResultDto.TimeRangeForm.Till, out DateTime till))
                throw new ArgumentException("Invalid till", timeRangeResultDto.TimeRangeForm.Till);

            if (!DateTime.TryParse(timeRangeResultDto.TimeRangeForm.From, out DateTime from))
                throw new ArgumentException("Invalid From", timeRangeResultDto.TimeRangeForm.From);

            var timeRangeDto = TimeRangeParse(timeRangeResultDto);

            if (string.IsNullOrEmpty(timeRangeResultDto.TimeRangeForm.Id) || timeRangeResultDto.TimeRangeForm.Id == "0")
                timeRangeDto = _timeRangeRepository.Insert(timeRangeDto);

            timeRangeDto = _timeRangeRepository.Update(timeRangeDto);

            return TimeRangeParse(timeRangeDto);
        }

        public TimeRangeResultDto GetTimeRange(int id)
        {
            if (id == 0)
                throw new ArgumentException("Empty id", nameof(id));

            TimeRangeDto timeRangeDto = _timeRangeRepository.GetById(id);
            if (timeRangeDto == null)
                throw new ArgumentException("Invalid timerange id", nameof(id));

            return TimeRangeParse(timeRangeDto);
        }

        public IList<TimeRangeResultDto> GetAllTimeRanges()
        {
            IList<TimeRangeDto> timeRangeDtos = _timeRangeRepository.GetAll();

            return timeRangeDtos.Select(timerange => TimeRangeParse(timerange)).ToList();
        }

        public bool DeleteTimeRange(int id)
        {
            if (id == 0)
                throw new ArgumentException("Empty id", nameof(id));

            var timeRangeDto = _timeRangeRepository.GetById(id);
            if (timeRangeDto == null || timeRangeDto.Id == 0)
                throw new ArgumentException("No timerange with Id found", nameof(id));

            return _timeRangeRepository.Delete(timeRangeDto);
        }

        private TimeRangeDto TimeRangeParse(TimeRangeResultDto timeRangeResultDto)
        {
            var timeRangeDto = new TimeRangeDto
            {
                Id = int.Parse(timeRangeResultDto.TimeRangeForm.Id),
                From = DateTime.Parse(timeRangeResultDto.TimeRangeForm.From),
                Till = DateTime.Parse(timeRangeResultDto.TimeRangeForm.Till)
            };

            return timeRangeDto;
        }

        private TimeRangeResultDto TimeRangeParse(TimeRangeDto timeRangeDto)
        {
            var timeRangeResultDto = new TimeRangeResultDto
            {
                TimeRangeForm = new TimeRangeForm()
            };
            timeRangeResultDto.TimeRangeForm.Id = timeRangeDto.Id.ToString();
            timeRangeResultDto.TimeRangeForm.From = timeRangeDto.From.ToString();
            timeRangeResultDto.TimeRangeForm.Till = timeRangeDto.Till.ToString();

            return timeRangeResultDto;
        }
    }
}
