using System;
using System.Collections.Generic;
using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Enums;
using Shared.Helpers;

namespace WebApi.Controllers{

    [ApiController]
    [Route("[controller]")]
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
        [Route("/")]
        public IActionResult GetCards(){
            var data = _cardService.GetCardById("864c261e-6df8-4788-8ac3-eb4c8a4a2bcf");
            return Ok(data);
        }

        [HttpGet]
        [Route("/new")]
        public IActionResult AddNewCards(){
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