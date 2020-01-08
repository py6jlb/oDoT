using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers{
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingsService _settingsService;

        public SettingsController(ILogger<SettingsController> logger, ISettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }

        [HttpGet]
        public IActionResult Get(){
            var result = _settingsService.GetSettings();
            return new JsonResult(result);
        }

        [HttpPost]  
        public IActionResult Post(SettingsModel model){
            if(model == null){
                return BadRequest();
            }
            var result = _settingsService.SaveSettings(new SettingsDto{
                Id = model.Id,
                DeadlineTimeSpanInMiliseconds = model.DeadlineTimeSpanInMiliseconds,
                DoNotDisturbTimeSpanInMiliseconds = model.DoNotDisturbTimeSpanInMiliseconds,
                PanicTimeSpanInMiliseconds = model.PanicTimeSpanInMiliseconds,
                StartPanicForTimeSpanInMiliseconds = model.StartPanicForTimeSpanInMiliseconds
            });
            return Ok(result);
        }
    }
}