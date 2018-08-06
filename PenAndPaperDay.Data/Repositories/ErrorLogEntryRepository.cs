using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class ErrorLogEntryRepository : BaseRepository<ErrorLogEntry, ErrorLogEntryDto>, IErrorLogEntryRepository
    {
        public ErrorLogEntryRepository(PenAndPaperDBContext dbContext, ILogger<ErrorLogEntryRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public IList<ErrorLogEntryDto> GetLogs(int pos, int count, bool asc)
        {
            var tags = _dbContext.ErrorLogEntries
                .OrderByWithDirection(tag => tag.Id, !asc)
                .Skip(pos)
                .Take(count)
                .ToList();

            return _mapper.Map<IList<ErrorLogEntry>, IList<ErrorLogEntryDto>>(tags);
        }
    }
}
