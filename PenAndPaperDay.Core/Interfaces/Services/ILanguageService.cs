using System;
using System.Collections.Generic;
using System.Text;
using PenAndPaperDay.Data.DTO;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface ILanguageService
    {
        /// <summary>
        /// Gets a list of all objects
        /// </summary>
        /// <returns>empty list or all objects</returns>
        IList<LanguageDto> GetAllLanguages();

        /// <summary>
        /// Gets an objects
        /// </summary>
        /// <returns>null or object</returns>
        LanguageDto GetLanguageByCode(string code);
    }
}
