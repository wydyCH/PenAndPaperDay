using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;
        private readonly ILogger<TagsController> _logger;

        public TagsController(ITagService tagService, ILogger<TagsController> logger)
        {
            _tagService = tagService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                object result = _tagService.GetTags();
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