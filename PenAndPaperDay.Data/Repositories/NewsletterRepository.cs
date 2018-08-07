using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class NewsletterRepository : BaseRepository<Newsletter, NewsletterDto>, INewsletterRepository
    {
        public NewsletterRepository(PenAndPaperDBContext dbContext, ILogger<NewsletterRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public NewsletterDto GetByEmail(string email)
        {
            var newsletter = _dbContext.Newsletters
                .FirstOrDefault(u => u.Email == email);

            return _mapper.Map<Newsletter, NewsletterDto>(newsletter);
        }
    }
}
