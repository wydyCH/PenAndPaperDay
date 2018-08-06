using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly ILogger<ContactUsController> _logger;

        public ContactUsController(IContactUsService contactUsService, ILogger<ContactUsController> logger)
        {
            _contactUsService = contactUsService;
            _logger = logger;
        }

        /// <summary>
        /// Creates a ContactUs E-mail
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ContactUsResult contactUs)
        {
            try
            {
                var result = _contactUsService.ContactUs(contactUs);
                return Ok(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }
    }
}