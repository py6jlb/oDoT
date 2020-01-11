using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using Shared.Helpers;

namespace BusinessLogic.DTO
{
    public class CardDto
    {
        public CardDto(){}

        public CardDto(Card newCard){
            Id = newCard.Id.ToString();
            CardComments = newCard.CardComments.Select(x=> new CardCommentDto{
                CreateDateTime = DateTimeHelper.ConverToMilisecond(x.CreateDateTime).Value,
                NotUserComment = x.NotUserComment,
                Text = x.Text,
                Id = x.Id.ToString()
            }).ToList();
            Content = new CardContentDto{
                Id = newCard.Content.Id.ToString(),
                Text = newCard.Content.Text
            };
            CreateDateTime = DateTimeHelper.ConverToMilisecond(newCard.CreateDateTime).Value;
            DeadLineDateTime = DateTimeHelper.ConverToMilisecond(newCard.DeadLineDateTime.Value);
            DefferalCount = newCard.DefferalCount;
            Name = newCard.Name;
            PanicIntervalInMiliseconds = newCard.PanicIntervalInMiliseconds;
            Priority = newCard.Priority;
            Status = newCard.Status;
            StartPanicDateTime = DateTimeHelper.ConverToMilisecond(newCard.StartPanicDateTime.Value);
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double CreateDateTime { get; set; }
        public double? DeadLineDateTime { get; set; }
        public double? StartPanicDateTime { get; set; }
        public double? PanicIntervalInMiliseconds { get; set; }
        public int DefferalCount { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public List<CardCommentDto> CardComments { get; set; }
        public CardContentDto Content { get; set; }
    }
}