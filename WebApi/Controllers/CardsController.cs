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
        public IActionResult Post(CardModel model){
            var data = new CardDto{
                CreateDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now).Value,
                Status = (int)CardStatusEnum.Open,
                Priority = (int)CardPriorityEnum.Normal,
                DeadLineDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now.AddDays(5)),
                DefferalCount = 0,
                DoNotDisturbInMiliseconds = 900000,
                Name = "Карточка для теста сохранения объекта",
                PanicIntervalInMiliseconds =  900000,
                StartPanicDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0))),
                Content = new CardContentDto{                   
                    Text = "kfjhlksdjfhgskdjfhgksdjfhgskldjfhgklsjdhglksd lsdfkg lsdkjfhg ksdfjkgh sd;fh sdfk"
                },
                CardComments = new List<CardCommentDto>{
                    new CardCommentDto{   
                        CreateDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now).Value,
                        NotUserComment = true,
                        Text = "ksdbajsdg kadg kjasd klj askj asdkljg as"
                    },
                    new CardCommentDto{    
                        CreateDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now.AddSeconds(40)).Value,
                        NotUserComment = false,
                        Text = "ksdbajsdg kadg kjasd klj askj asdkljg as"
                    },
                    new CardCommentDto{   
                        CreateDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now.AddSeconds(100)).Value,
                        NotUserComment = false,
                        Text = "ksdbajsdg kadg kjasd klj askj asdkljg as"
                    },
                    new CardCommentDto{     
                        CreateDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now.AddSeconds(150)).Value,
                        NotUserComment = true,
                        Text = "ksdbajsdg kadg kjasd klj askj asdkljg as"
                    },
                    new CardCommentDto{   
                        CreateDateTime = DateTimeHelper.ConverToMilisecond(DateTime.Now.AddSeconds(200)).Value,
                        NotUserComment = true,
                        Text = "ksdbajsdg kadg kjasd klj askj asdkljg as"
                    }
                }
            };
            var t = _cardService.AddCard(data);
            return Ok(t);
        }
    }
}