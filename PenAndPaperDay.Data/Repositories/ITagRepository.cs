using System.Collections.Generic;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface ITagRepository : IBaseRepository<Tag, TagDto>
    {
        IList<TagDto> GetTags(int pos, int count, bool asc);
    }
}
