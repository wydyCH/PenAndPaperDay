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
    public class TimeRangeController : Controller
    {
        private readonly ITimeRangeService _timeRangeService;
        private readonly ILogger<TimeRangeController> _logger;

        public TimeRangeController(ITimeRangeService timeRangeService, ILogger<TimeRangeController> logger)
        {
            _timeRangeService = timeRangeService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TimeRangeResultDto timeRange)
        {
            try
            {
                object timeRangeDto = _timeRangeService.SaveTimeRange(timeRange);
                return Ok(timeRangeDto);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                object result = _timeRangeService.GetTimeRange(id);
                return Ok(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool success = _timeRangeService.DeleteTimeRange(id);
                if (success)
                {
                    return Ok();
                }

                return BadRequest("Can't delete TimeRange");
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }
    }
}