using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Attbutes;
using WebApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Contracts.V1;
using WebApi.Contracts.V1.Requests.Queries;

namespace WebApi.Controllers
{
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ILogger<CardsController> _logger;
        private readonly ICardService _cardService;
        public CardsController(ILogger<CardsController> logger, ICardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
        }

        [HttpGet(ApiRoutes.Cards.GetAll)]
        public IActionResult GetAll([FromQuery]GetAllCardsQuery query)
        {
            var data = query.Status.HasValue ? _cardService.GetCardsByStatus(query.Status.Value) :_cardService.GetCards();
            return Ok(data != null && data.Any() ? data.ToArray() : new object[0]);
        }

        [HttpGet(ApiRoutes.Cards.Get)]
        public IActionResult GetById(string id)
        {
            var data = _cardService.GetCardById(id);
            return Ok(data);
        }

        [HttpPost(ApiRoutes.Cards.Create)]
        public IActionResult Post(CardModel model)
        {
            var data = new CardDto
            {
                CreateDateTime = model.CreateDateTime,
                Status = model.Status,
                Priority = model.Priority,
                DeadLineDateTime = model.DeadLineDateTime,
                DefferalCount = model.DefferalCount,
                Name = model.Name,
                PanicIntervalInMiliseconds = model.PanicIntervalInMiliseconds,
                StartPanicDateTime = model.StartPanicDateTime,
                Content = new CardContentDto
                {
                    Text = model.Content.Text
                },
                CardComments = new List<CardCommentDto>()
            };
            var result = _cardService.AddCard(data);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Cards.Delete)]
        public IActionResult Delete(string id)
        {
            var data = _cardService.DeleteCard(id);
            return Ok(data);
        }

        [HttpPut(ApiRoutes.Cards.Update)]
        public IActionResult Put(CardModel model)
        {
            var dto = new CardDto
            {
                Id = model.Id,
                CreateDateTime = model.CreateDateTime,
                Status = model.Status,
                Priority = model.Priority,
                DeadLineDateTime = model.DeadLineDateTime,
                DefferalCount = model.DefferalCount,
                Name = model.Name,
                PanicIntervalInMiliseconds = model.PanicIntervalInMiliseconds,
                StartPanicDateTime = model.StartPanicDateTime
            };

            var data = _cardService.UpdateCard(dto);
            return Ok(data);
        }
    }
}