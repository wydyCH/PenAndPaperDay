using System.Collections.Generic;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface IOfferedGameRepository : IBaseRepository<OfferedGame, OfferedGameDto>
    {
        IList<OfferedGameDto> GetAll(string code);
    }
}
