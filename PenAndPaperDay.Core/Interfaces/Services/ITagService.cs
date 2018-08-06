using System.Collections.Generic;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface ITagService
    {
        /// <summary>
        /// Gets a list of all objects
        /// </summary>
        /// <returns>empty list or all objects</returns>
        IList<TagResult> GetTags(int pos, int count, bool asc, string language);

        /// <summary>
        /// Update or Insert an object
        /// </summary>
        /// <param name="tagResult"></param>
        /// <returns>null or object</returns>
        TagResult SaveTag(TagResult tagResult);

        /// <summary>
        /// Gets an object
        /// </summary>
        /// <returns>null or object</returns>
        TagResult GetTag(int id);

        /// <summary>
        /// deletes an object
        /// </summary>
        /// <returns>bool if worked</returns>
        bool DeleteTag(int id);
    }
}
