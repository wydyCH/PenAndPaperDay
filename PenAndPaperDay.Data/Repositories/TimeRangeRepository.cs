using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class TimeRangeRepository : BaseRepository<TimeRange, TimeRangeDto>, ITimeRangeRepository
    {
        public TimeRangeRepository(PenAndPaperDBContext dbContext, ILogger<TimeRangeRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }
    }
}
