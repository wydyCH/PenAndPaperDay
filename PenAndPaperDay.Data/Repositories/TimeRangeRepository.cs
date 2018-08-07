using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class TimeRangeRepository : BaseRepository<TimeRange, TimeRangeDto>, ITimeRangeRepository
    {
        public TimeRangeRepository(PenAndPaperDBContext dbContext, ILogger<TimeRangeRepository> logger, IMapper mapper)
            : base(dbContext, logger, mapper)
        {
        }

        public new TimeRangeDto GetById(object id)
        {
            var timeRange = _dbContext.TimeRanges
                .Include(s => s.UserOnTimeRange)
                .FirstOrDefault(i => i.Id == (int) id);

            if (timeRange != null)
            {
                return _mapper.Map<TimeRange, TimeRangeDto>(timeRange);
            }

            return null;
        }

        public new bool Delete(TimeRangeDto timeRangeDto)
        {
            var timeRange = _dbContext.Find<TimeRange>(timeRangeDto.Id);
            _dbContext.TimeRanges.Remove(timeRange);

            _dbContext.SaveChanges();

            return true;
        }
    }
}
