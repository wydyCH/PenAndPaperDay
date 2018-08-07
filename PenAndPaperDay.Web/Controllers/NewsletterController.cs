using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly ILogger<NewsletterController> _logger;

        public NewsletterController(INewsletterService newsletterService, ILogger<NewsletterController> logger)
        {
            _newsletterService = newsletterService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewsletterResult user)
        {
            try
            {
                object userResult = _newsletterService.SaveNewsletter(user);
                return Ok(userResult);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(string email)
        {
            try
            {
                object result = _newsletterService.GetNewsletter(email);
                return Json(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string email)
        {
            try
            {
                bool success = _newsletterService.DeleteNewsletter(email);
                if (success)
                {
                    return Ok();
                }

                return BadRequest("Can't delete Newsletter");
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }
    }
}