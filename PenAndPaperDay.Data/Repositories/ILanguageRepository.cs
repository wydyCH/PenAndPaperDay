using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface ILanguageRepository : IBaseRepository<Language, LanguageDto>
    {
        LanguageDto GetByCode(string code);
    }
}
