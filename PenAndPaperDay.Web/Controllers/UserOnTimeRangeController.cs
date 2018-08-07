using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserOnTimeRangeController : Controller
    {
        private readonly IUserOnTimeRangeService _userOnTimeService;
        private readonly ILogger<UserOnTimeRangeController> _logger;

        public UserOnTimeRangeController(IUserOnTimeRangeService userOnTimeService, ILogger<UserOnTimeRangeController> logger)
        {
            _userOnTimeService = userOnTimeService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserOnTimeRangeResult userOnTimeResult)
        {
            try
            {
                object offeredGameResult = _userOnTimeService.SaveUserOnTimeRange(userOnTimeResult);
                return Ok(offeredGameResult);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(string code)
        {
            try
            {
                object result = _userOnTimeService.GetUserOnTimeRanges(code);
                return Json(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(string code)
        {
            try
            {
                bool success = _userOnTimeService.DeleteuserOnTimeRanges(code);
                if (success)
                {
                    return Ok();
                }

                return BadRequest("Can't delete OfferedGame");
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }
    }
}