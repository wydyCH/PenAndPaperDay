using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class NewslettersController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly ILogger<NewslettersController> _logger;

        public NewslettersController(INewsletterService newsletterService, ILogger<NewslettersController> logger)
        {
            _newsletterService = newsletterService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int pos, int count, bool asc, string language)
        {
            try
            {
                object result = _newsletterService.GetAllNewsletter();
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