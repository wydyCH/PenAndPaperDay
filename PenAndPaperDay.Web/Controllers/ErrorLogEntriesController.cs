using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenAndPaperDay.Core.Interfaces.Services;

namespace PenAndPaperDay.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ErrorLogEntriesController : Controller
    {
        private readonly IErrorLogEntryService _errorLogEntryService;
        private readonly ILogger<ErrorLogEntriesController> _logger;

        public ErrorLogEntriesController(IErrorLogEntryService errorLogEntryService, ILogger<ErrorLogEntriesController> logger)
        {
            _errorLogEntryService = errorLogEntryService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(int pos, int count, bool asc)
        {
            try
            {
                object result = _errorLogEntryService.GetLogs(pos, count, asc);
                return Json(result);
            }
            catch (Exception exc)
            {
                _logger.LogError(exc, exc.Message);
                return BadRequest(exc.Message);
            }
        }
    }
}