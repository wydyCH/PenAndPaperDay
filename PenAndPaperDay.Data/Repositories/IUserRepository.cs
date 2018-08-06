using System.Collections.Generic;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface IUserRepository : IBaseRepository<User, UserDto>
    {
        UserDto GetByCode(string code);

        IList<UserDto> GetUsers(int pos, int count, bool asc);
    }
}
