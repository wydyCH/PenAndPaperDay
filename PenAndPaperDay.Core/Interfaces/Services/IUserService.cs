using System;
using System.Collections.Generic;
using System.Text;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Gets a list of all objects
        /// </summary>
        /// <returns>empty list or all objects</returns>
        IList<UserResult> GetUsers(int pos, int count, bool asc);

        /// <summary>
        /// Update or Insert an object
        /// </summary>
        /// <param name="userResult"></param>
        /// <returns>null or object</returns>
        UserResult SaveUser(UserResult userResult);

        /// <summary>
        /// Gets an object
        /// </summary>
        /// <returns>null or object</returns>
        UserResult GetUser(string code);

        /// <summary>
        /// deletes an object
        /// </summary>
        /// <returns>bool if worked</returns>
        bool DeleteUser(string code);
    }
}
