using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Abstraction;
using BusinessLogic.DTO;
using DataAccess.Entities;
using DataAccess.Repositories.Abstractions;
using Microsoft.Extensions.Logging;
using Shared.Helpers;

namespace BusinessLogic{

    public class CardService : ICardService
    {
        private readonly ILogger<CardService> _logger;
        private readonly ICardRepository _cardRepo;
        private readonly ICardCommentRepository _cardCommentRepo;
        private readonly ICardContentRepository _cardContentRepo;
        public CardService(
            ILogger<CardService> logger, 
            ICardRepository cardRepo, 
            ICardCommentRepository cardCommentRepo,
            ICardContentRepository cardContentRepo
        ){
            _logger = logger;
            _cardRepo = cardRepo;
            _cardCommentRepo = cardCommentRepo;
            _cardContentRepo = cardContentRepo;
        }

        public CardDto AddCard(CardDto newCard)
        {
            if(newCard.Content != null){
                var content = AddCardContent(newCard.Content);
                newCard.Content = content;
            }

            if(newCard.CardComments != null && newCard.CardComments.Any()){
                var comments = AddCardComments(newCard.CardComments);
                newCard.CardComments = comments.ToList();;
            }

            var cardEntty = new Card{
                CardComments = newCard.CardComments.Select(x=> new CardComment{
                    CreateDateTime = DateTimeHelper.MilisecondToDateTime(x.CreateDateTime).Value,
                    NotUserComment = x.NotUserComment,
                    Text = x.Text,
                    Id = Guid.Parse(x.Id)
                }).ToList(),
                Content = new CardContent{
                    Id = Guid.Parse(newCard.Content.Id),
                    Text = newCard.Content.Text
                },
                CreateDateTime = DateTimeHelper.MilisecondToDateTime(newCard.CreateDateTime).Value,
                DeadLineDateTime = newCard.DeadLineDateTime.HasValue ? DateTimeHelper.MilisecondToDateTime(newCard.DeadLineDateTime.Value) : null,
                DefferalCount = newCard.DefferalCount,
                Name = newCard.Name,
                PanicIntervalInMiliseconds = newCard.PanicIntervalInMiliseconds,
                Priority = newCard.Priority,
                Status = newCard.Status,
                StartPanicDateTime = newCard.StartPanicDateTime.HasValue ? DateTimeHelper.MilisecondToDateTime(newCard.StartPanicDateTime.Value) : null
            };

            var card = _cardRepo.AddCard(cardEntty);

            var result = new CardDto(card);
            return result;
        }

        public CardCommentDto AddCardComment(CardCommentDto newCardComment)
        {
            var entity = new CardComment{
                NotUserComment = newCardComment.NotUserComment,
                Text = newCardComment.Text,
                CreateDateTime = DateTimeHelper.MilisecondToDateTime(newCardComment.CreateDateTime).Value
            };

            var cardComment = _cardCommentRepo.AddComment(entity);
            var result = new CardCommentDto(cardComment);
            return result;
        }

        public IEnumerable<CardCommentDto> AddCardComments(IEnumerable<CardCommentDto> newCardComments)
        {
            var entities = newCardComments.Select(x=> new CardComment{
                NotUserComment = x.NotUserComment,
                Text = x.Text,
                CreateDateTime = DateTimeHelper.MilisecondToDateTime(x.CreateDateTime).Value
            });
            var cardComment = _cardCommentRepo.AddComments(entities);
            var result = cardComment.Select(x=> new CardCommentDto(x));
            return result;
        }

        public CardContentDto AddCardContent(CardContentDto newCardComment)
        {
            var entity = new CardContent{
                Text = newCardComment.Text
            };

            var cardComment = _cardContentRepo.AddContent(entity);
            var result = new CardContentDto(cardComment);
            return result;
        }

        public CardDto GetCardById(string guid)
        {
            var parsedGuid = Guid.Parse(guid);
            var data = _cardRepo.GetCardById(parsedGuid);

            var result = new CardDto(data);
                
            return result;
        }

        public IEnumerable<CardDto> GetCards()
        {
            var data = _cardRepo.GetCards();
            var result = data.Select(x=> new CardDto(x));                
            return result;
        }
    }
}