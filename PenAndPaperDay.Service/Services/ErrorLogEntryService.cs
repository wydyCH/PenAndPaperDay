using PenAndPaperDay.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class ErrorLogEntryService : IErrorLogEntryService
    {

        private readonly IErrorLogEntryRepository _errorLogEntryRepository;

        public ErrorLogEntryService(IErrorLogEntryRepository errorLogEntryRepository)
        {
            _errorLogEntryRepository = errorLogEntryRepository;
        }

        public IList<ErrorLogEntryDto> GetLogs(int pos, int count, bool asc)
        {
            return _errorLogEntryRepository.GetLogs(pos, count, asc);
        }
    }
}
