using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class OfferedGameOnTagRepository : BaseRepository<OfferedGameOnTag, OfferedGameOnTagDto>, IOfferedGameOnTagRepository
    {
        public OfferedGameOnTagRepository(PenAndPaperDBContext dbContext, ILogger<OfferedGameOnTagRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }
    }
}
