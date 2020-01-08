using BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers{
    public class CardContentController : ControllerBase
    {
        private readonly ILogger<CardContentController> _logger;
        private readonly ICardService _cardService;

        public CardContentController(ILogger<CardContentController> logger, ICardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
        }
    }
}