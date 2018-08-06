using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;
using PenAndPaperDay.Data.Enum;

namespace PenAndPaperDay.Data.Repositories
{
    public class UserOnOfferedGameRepository : BaseRepository<UserOnOfferedGame, UserOnOfferedGameDto>, IUserOnOfferedGameRepository
    {
        public UserOnOfferedGameRepository(PenAndPaperDBContext dbContext, ILogger<UserOnOfferedGameRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }
    }
}
