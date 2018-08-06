using System;
using System.Collections.Generic;
using System.Text;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Repositories;

namespace PenAndPaperDay.Service.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public IList<LanguageDto> GetAllLanguages()
        {
            return _languageRepository.GetAll();
        }

        public LanguageDto GetLanguageByCode(string code)
        {
            return _languageRepository.GetByCode(code);
        }
    }
}
