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
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("{status:int}")]
        public IActionResult Get(int status){
            var data = _cardService.GetCardsByStatus(status);
            return Ok(data != null && data.Any() ? data.ToArray() : new object[0]);
        }

        [HttpPost]
        public IActionResult Post(CardModel model){
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

        [HttpDelete("{id}")]
        public IActionResult Delete(string id){
            var data = _cardService.DeleteCard(id);
            return Ok(data);
        }

        [HttpPut]
        public IActionResult Put(CardModel model){
            var data = _cardService.CloseCard(model.Id);
            return Ok(data);
        }
    }
}