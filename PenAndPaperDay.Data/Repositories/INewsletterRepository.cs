using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface INewsletterRepository: IBaseRepository<Newsletter, NewsletterDto>
    {
        NewsletterDto GetByEmail(string email);
    }
}
