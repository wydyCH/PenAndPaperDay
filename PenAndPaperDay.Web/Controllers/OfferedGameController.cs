using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;
using PenAndPaperDay.Data.DTO.RestDto;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OfferedGameController : Controller
    {
        private readonly IOfferedGameService _offeredGameService;
        private readonly ILogger<OfferedGameController> _logger;

        public OfferedGameController(IOfferedGameService offeredGameService, ILogger<OfferedGameController> logger)
        {
            _offeredGameService = offeredGameService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] OfferedGameResult offeredGame)
        {
            try
            {
                object offeredGameResult = _offeredGameService.SaveOfferedGame(offeredGame);
                return Ok(offeredGameResult);
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
                object result = _offeredGameService.GetOfferedGame(id);
                return Json(result);
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
                bool success = _offeredGameService.DeleteOffered(id);
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