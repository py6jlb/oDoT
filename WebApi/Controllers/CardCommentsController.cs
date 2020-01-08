using BusinessLogic.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers{
    public class CardCommentsController : ControllerBase
    {
        private readonly ILogger<CardCommentsController> _logger;
        private readonly ICardService _cardService;

        public CardCommentsController(ILogger<CardCommentsController> logger, ICardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
        }
        
    }
}