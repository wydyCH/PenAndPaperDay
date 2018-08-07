using System;
using System.Collections.Generic;
using System.Text;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.Entites;

namespace PenAndPaperDay.Data.Repositories
{
    public interface IUserOnTimeRangeRepository : IBaseRepository<UserOnTimeRange, UserOnTimeRangeDto>
    {
        void Clear(UserDto user);

        IList<UserOnTimeRangeDto> GetAll(UserDto user);
    }
}
