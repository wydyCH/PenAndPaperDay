using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class UserOnTimeRangeRepository : BaseRepository<UserOnTimeRange, UserOnTimeRangeDto>, IUserOnTimeRangeRepository
    {
        public UserOnTimeRangeRepository(PenAndPaperDBContext dbContext, ILogger<UserOnTimeRangeRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public void Clear(UserDto user)
        {
            var times = GetAll(user);
            foreach (var time in times)
            {
                Delete(time);
            }
        }

        public IList<UserOnTimeRangeDto> GetAll(UserDto user)
        {
            var result = _dbContext.UserOnTimeRanges.Where(us => us.UserId == user.Id);

            return _mapper.Map<IList<UserOnTimeRange>, IList<UserOnTimeRangeDto>>(result.ToList());
        }
    }
}
