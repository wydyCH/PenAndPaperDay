using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public class UserRepository : BaseRepository<User, UserDto>, IUserRepository
    {
        public UserRepository(PenAndPaperDBContext dbContext, ILogger<UserRepository> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public UserDto GetByCode(string code)
        {
            var user =  _dbContext.Users
                .FirstOrDefault(u => u.Code == code);

            return _mapper.Map<User, UserDto> (user);
        }

        public IList<UserDto> GetUsers(int pos, int count, bool asc)
        {
            var users = _dbContext.Users
                .OrderByWithDirection(tag => tag.Email, !asc)
                .Skip(pos)
                .Take(count)
                .ToList();

            return _mapper.Map<IList<User>, IList<UserDto>>(users);
        }
    }
}
