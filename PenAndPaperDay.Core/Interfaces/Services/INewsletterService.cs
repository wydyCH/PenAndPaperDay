using System;
using System.Collections.Generic;
using System.Text;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Core.Interfaces.Services
{
    public interface INewsletterService
    {
        /// <summary>
        /// Gets a list of all objects
        /// </summary>
        /// <returns>empty list or all objects</returns>
        IList<NewsletterResult> GetAllNewsletter();

        /// <summary>
        /// Update or Insert an object
        /// </summary>
        /// <param name="newsletterResult"></param>
        /// <returns>null or object</returns>
        NewsletterResult SaveNewsletter(NewsletterResult newsletterResult);

        /// <summary>
        /// Gets an object
        /// </summary>
        /// <returns>null or object</returns>
        NewsletterResult GetNewsletter(string email);

        /// <summary>
        /// deletes an object
        /// </summary>
        /// <returns>bool if worked</returns>
        bool DeleteNewsletter(string email);
    }
}
