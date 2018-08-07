using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface IUserOnTimeRangeService
    {
        UserOnTimeRangeResult SaveUserOnTimeRange(UserOnTimeRangeResult userOnTimeResult);

        UserOnTimeRangeResult GetUserOnTimeRanges(string code);

        bool DeleteuserOnTimeRanges(string code);
    }
}
