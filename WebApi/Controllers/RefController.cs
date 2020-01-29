using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared;
using Shared.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using WebApi.Contracts.V1;

namespace WebApi.Controllers
{
    [ApiController]
    public class RefController : ControllerBase
    {
        private readonly ILogger<RefController> _logger;

        public RefController(ILogger<RefController> logger)
        {
            _logger = logger;
        }

        [HttpGet(ApiRoutes.Ref.Get)]
        public IActionResult GetRefs(string id)
        {
            switch (id)
            {
                case ("status"):
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
    }
}