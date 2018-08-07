using System;
using System.Collections.Generic;
using System.Linq;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class UserOnTimeRangeService : IUserOnTimeRangeService
    {
        private readonly IUserOnTimeRangeRepository _userOnTimeRangeRepository;
        private readonly IUserRepository _userRepository;

        //TODO in config
        private readonly string _timePrefix = "opt-";

        public UserOnTimeRangeService(IUserOnTimeRangeRepository userOnTimeRangeRepository, IUserRepository userRepository)
        {
            _userOnTimeRangeRepository = userOnTimeRangeRepository;
            _userRepository = userRepository;
        }

        public UserOnTimeRangeResult SaveUserOnTimeRange(UserOnTimeRangeResult userOnTimeRangeResult)
        {
            if (userOnTimeRangeResult == null || userOnTimeRangeResult.UserOnTimeRangeForm == null)
                throw new ArgumentNullException("No userOnTimeRangeResult send");

            if (string.IsNullOrEmpty(userOnTimeRangeResult.UserOnTimeRangeForm.Code))
                throw new ArgumentNullException("No Code send");

            var userDto = _userRepository.GetByCode(userOnTimeRangeResult.UserOnTimeRangeForm.Code);
            if(userDto == null)
                throw new ArgumentException("Invalid code", nameof(userOnTimeRangeResult.UserOnTimeRangeForm.Code));

            var userOnTimeRangeDtos = UserOnTimeRangeParse(userOnTimeRangeResult);
            
            _userOnTimeRangeRepository.Clear(userDto);
            userOnTimeRangeDtos = _userOnTimeRangeRepository.Insert(userOnTimeRangeDtos);

            return UserOnTimeRangeParse(userOnTimeRangeDtos);
        }

        public UserOnTimeRangeResult GetUserOnTimeRanges(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("No code send");

            var userDto = _userRepository.GetByCode(code);
            if (userDto == null)
                throw new ArgumentException("invalid code", nameof(code));

            IList<UserOnTimeRangeDto> userOnTimeRanges = _userOnTimeRangeRepository.GetAll(userDto);

            return UserOnTimeRangeParse(userOnTimeRanges);
        }

        public bool DeleteuserOnTimeRanges(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException("No code send");

            var userDto = _userRepository.GetByCode(code);
            if (userDto == null)
                throw new ArgumentException("invalid code", nameof(code));

            IList<UserOnTimeRangeDto> userOnTimes = _userOnTimeRangeRepository.GetAll(userDto);

            return _userOnTimeRangeRepository.Delete(userOnTimes);
        }

        private IList<UserOnTimeRangeDto> UserOnTimeRangeParse(UserOnTimeRangeResult userOnTimeRangeResult)
        {
            IList<UserOnTimeRangeDto> userOnTimeRangeDtos = new List<UserOnTimeRangeDto>();
            UserDto user = _userRepository.GetByCode(userOnTimeRangeResult.UserOnTimeRangeForm.Code);

            if (userOnTimeRangeResult.UserOnTimeRangeForm.TimeRanges.Any())
            {
                foreach (var time in userOnTimeRangeResult.UserOnTimeRangeForm.TimeRanges)
                {
                    string timerangestring = time.Key.Replace(_timePrefix, "");
                    
                    if (int.TryParse(timerangestring, out int timeId))
                    {
                        UserOnTimeRangeDto userOnTimeRangeDto = new UserOnTimeRangeDto()
                        {
                            TimeRangeId = timeId,
                            UserId = user.Id
                        };

                        userOnTimeRangeDtos.Add(userOnTimeRangeDto);
                    }
                }
            }

            return userOnTimeRangeDtos;
        }

        private UserOnTimeRangeResult UserOnTimeRangeParse(IList<UserOnTimeRangeDto> userOnTimeRangeDtos)
        {
            UserOnTimeRangeResult userOnTimeRangeResult = new UserOnTimeRangeResult()
            {
                UserOnTimeRangeForm = new UserOnTimeRangeForm()
            };

            if (userOnTimeRangeDtos.Any())
            {
                userOnTimeRangeResult.UserOnTimeRangeForm.TimeRanges = new Dictionary<string, string>();
                foreach (var time in userOnTimeRangeDtos)
                {
                    userOnTimeRangeResult.UserOnTimeRangeForm.TimeRanges.Add(_timePrefix + time.TimeRangeId, "on");
                }

                //TODO Check if valid
                userOnTimeRangeResult.UserOnTimeRangeForm.Code = userOnTimeRangeDtos[0].User.Code;
            }

            return userOnTimeRangeResult;
        }

    }
}
