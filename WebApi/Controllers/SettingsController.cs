using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using Shared;
using Shared.Enums;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApi.Controllers{
    [ApiController]
    [Route("api/[controller]")]
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
                PanicTimeSpanInMiliseconds = model.PanicTimeSpanInMiliseconds,
                StartPanicForTimeSpanInMiliseconds = model.StartPanicForTimeSpanInMiliseconds
            });
            return Ok(result);
        }
        
        [HttpGet("statuses")]
        public IActionResult Statuses(){
            var data = (CardStatusEnum[])Enum.GetValues(typeof(CardStatusEnum));
            var result = new List<CardStatusEnum>(data).Select(x=> new{
                Key = (int)x,
                Value = x.GetEnumDescription()
            });
            return Ok(result);
        }

        [HttpGet("priority")]
        public IActionResult Priority(){
            var data = (CardPriorityEnum[])Enum.GetValues(typeof(CardPriorityEnum));
            var result = new List<CardPriorityEnum>(data).Select(x=> new{
                Key = (int)x,
                Value = x.GetEnumDescription()
            });
            return Ok(result);
        }

    }
}