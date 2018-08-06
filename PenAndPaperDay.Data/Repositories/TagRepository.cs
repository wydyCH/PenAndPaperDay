using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class TagRepository : BaseRepository<Tag, TagDto>, ITagRepository
    {
        public TagRepository(PenAndPaperDBContext dbContext, ILogger<TagRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public IList<TagDto> GetTags(int pos, int count, bool asc)
        {
            var tags = _dbContext.Tags
                .OrderByWithDirection(tag => tag.Name, !asc)
                .Skip(pos)
                .Take(count)
                .ToList();

            return _mapper.Map<IList<Tag>, IList<TagDto>>(tags);
        }
    }
}
