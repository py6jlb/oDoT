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
using WebApi.Attbutes;

namespace WebApi.Controllers
{
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
        public IActionResult GetSettings()
        {
            var result = _settingsService.GetSettings();
            return new JsonResult(result);
        }

        [HttpGet]
        [ExactQueryParam("refname")]
        public IActionResult GetStatuses([FromQuery] string refname)
        {
            switch (refname)
            {
                case ("statuses"):
                    var statuses = (CardStatusEnum[])Enum.GetValues(typeof(CardStatusEnum));
                    var statusesList = new List<CardStatusEnum>(statuses).Select(x => new
                    {
                        Key = (int)x,
                        Value = x.GetEnumDescription()
                    });
                    return Ok(statusesList);
                case ("priority"):
                    var priority = (CardPriorityEnum[])Enum.GetValues(typeof(CardPriorityEnum));
                    var priorityList = new List<CardPriorityEnum>(priority).Select(x => new
                    {
                        Key = (int)x,
                        Value = x.GetEnumDescription()
                    });
                    return Ok(priorityList);
                default:
                    return Ok();
            }
        }

        [HttpPost]
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