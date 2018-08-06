using System.Collections;
using System.Collections.Generic;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface ITimeRangeService
    {
        /// <summary>
        /// Update or Insert an object
        /// </summary>
        /// <param name="timeRangeResultDto"></param>
        /// <returns>null or object</returns>
        TimeRangeResultDto SaveTimeRange(TimeRangeResultDto timeRangeResultDto);

        /// <summary>
        /// Gets an object
        /// </summary>
        /// <returns>null or object</returns>
        TimeRangeResultDto GetTimeRange(int id);

        /// <summary>
        /// Gets a list of all objects
        /// </summary>
        /// <returns>empty list or all objects</returns>
        IList<TimeRangeResultDto> GetAllTimeRanges();

        /// <summary>
        /// deletes an object
        /// </summary>
        /// <returns>bool if worked</returns>
        bool DeleteTimeRange(int id);
    }
}
