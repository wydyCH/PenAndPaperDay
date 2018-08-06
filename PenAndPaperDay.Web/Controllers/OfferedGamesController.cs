using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class OfferedGamesController : Controller
    {
        private readonly IOfferedGameService _offeredGameService;
        private readonly ILogger<OfferedGamesController> _logger;

        public OfferedGamesController(IOfferedGameService offeredGameService, ILogger<OfferedGamesController> logger)
        {
            _offeredGameService = offeredGameService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string code)
        {
            try
            {
                object result = _offeredGameService.GetOfferedGames(code);
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