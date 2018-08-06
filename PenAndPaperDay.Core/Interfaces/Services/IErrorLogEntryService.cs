using System;
using System.Collections.Generic;
using System.Text;
using PenAndPaperDay.Data.DTO;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface IErrorLogEntryService
    {
        /// <summary>
        /// Gets a list of all objects
        /// </summary>
        /// <returns>empty list or all objects</returns>
        IList<ErrorLogEntryDto> GetLogs(int pos, int count, bool asc);
    }
}
