using System.Collections.Generic;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface IOfferedGameService
    {
        /// <summary>
        /// Gets a list of all objects
        /// </summary>
        /// <returns>empty list or all objects</returns>
        IList<OfferedGameResult> GetOfferedGames(string code);

        /// <summary>
        /// Update or Insert an object
        /// </summary>
        /// <param name="tagResult"></param>
        /// <returns>null or object</returns>
        OfferedGameResult SaveOfferedGame(OfferedGameResult tagResult);

        /// <summary>
        /// Gets an object
        /// </summary>
        /// <returns>null or object</returns>
        OfferedGameResult GetOfferedGame(int id);

        /// <summary>
        /// deletes an object
        /// </summary>
        /// <returns>bool if worked</returns>
        bool DeleteOffered(int id);
    }
}
