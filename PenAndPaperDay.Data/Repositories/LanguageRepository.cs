using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class LanguageRepository : BaseRepository<Language, LanguageDto>, ILanguageRepository
    {
        public LanguageRepository(PenAndPaperDBContext dbContext, ILogger<LanguageRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public LanguageDto GetByCode(string code)
        {
            var language =_dbContext.Languages.FirstOrDefault(c => c.TwoDigitSeoCode == code);

            return _mapper.Map<Language, LanguageDto>(language);
        }
    }
}
