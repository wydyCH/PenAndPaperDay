using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TimeRangesController : Controller
    {
        private readonly ITimeRangeService _timeRangeService;
        private readonly ILogger<TimeRangesController> _logger;

        public TimeRangesController(ITimeRangeService timeRangeService, ILogger<TimeRangesController> logger)
        {
            _timeRangeService = timeRangeService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                object result = _timeRangeService.GetAllTimeRanges();
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