using System.Collections.Generic;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface IErrorLogEntryRepository : IBaseRepository<ErrorLogEntry, ErrorLogEntryDto>
    {
        IList<ErrorLogEntryDto> GetLogs(int pos, int count, bool asc);
    }
}
