using System;
using DataAccess.Entities;
using Shared.Helpers;

namespace BusinessLogic.DTO
{
    public class CardCommentDto
    {
        public CardCommentDto(){}
        public CardCommentDto(CardComment newCardComment){
            Id = newCardComment.Id.ToString();
            NotUserComment = newCardComment.NotUserComment;
            Text = newCardComment.Text;
            CreateDateTime = DateTimeHelper.ConverToMilisecond(newCardComment.CreateDateTime).Value;
        }

        public string Id { get; set; }
        public string Text { get; set; }
        public double CreateDateTime { get; set; }
        public bool NotUserComment { get; set; }
    }
}