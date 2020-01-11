using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Enums;
using Shared.Helpers;
using WebApi.Models;

namespace WebApi.Controllers{
    public class CardsController : ControllerBase
    {
        private readonly ILogger<CardsController> _logger;
        private readonly ICardService _cardService;

        public CardsController(ILogger<CardsController> logger, ICardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
        }
        
        [HttpGet]
        public IActionResult Get(){
            var data = _cardService.GetCards();
            return Ok(data != null && data.Any() ? data.ToArray() : new object[0]);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CardModel model){
            return Ok(model);
        }
    }
}