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

        [HttpGet]
        public IActionResult GetByStatus([FromQuery]int status){
            var data = _cardService.GetCardsByStatus(status);
            return Ok(data != null && data.Any() ? data.ToArray() : new object[0]);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CardModel model){
            var data = new CardDto{
                CreateDateTime = model.CreateDateTime,
                Status = model.Status,
                Priority = model.Priority,
                DeadLineDateTime = model.DeadLineDateTime,
                DefferalCount = model.DefferalCount,
                Name = model.Name,
                PanicIntervalInMiliseconds = model.PanicIntervalInMiliseconds,
                StartPanicDateTime = model.StartPanicDateTime,
                Content = new CardContentDto{                   
                    Text = model.Content.Text
                },
                CardComments = new List<CardCommentDto>()
            };
            var result = _cardService.AddCard(data);
            return Ok(result);
        }


        [HttpGet]
        public IActionResult DeleteCard([FromQuery]string id){
            var data = _cardService.DeleteCard(id);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult CloseCard([FromQuery]string id){
            var data = _cardService.CloseCard(id);
            return Ok(data);
        }
    }
}