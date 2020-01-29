using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using WebApi.Contracts.V1;

namespace WebApi.Controllers
{
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingsService _settingsService;

        public SettingsController(ILogger<SettingsController> logger, ISettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        [HttpGet(ApiRoutes.Settings.Get)]
        public IActionResult GetSettings()
        {
            var result = _settingsService.GetSettings();
            return new JsonResult(result);
        }

        [HttpPost(ApiRoutes.Settings.Update)]
        public IActionResult Post(SettingsModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _settingsService.SaveSettings(new SettingsDto
            {
                Id = model.Id,
                DeadlineTimeSpanInMiliseconds = model.DeadlineTimeSpanInMiliseconds,
                PanicTimeSpanInMiliseconds = model.PanicTimeSpanInMiliseconds,
                StartPanicForTimeSpanInMiliseconds = model.StartPanicForTimeSpanInMiliseconds
            });
            return Ok(result);
        }
    }
}