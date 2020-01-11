using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class CardModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double CreateDateTimeInMiliseconds { get; set; }
        public double? DeadLineDateTimeInMiliseconds { get; set; }
        public double? StartPanicDateTimeInMiliseconds { get; set; }
        public double? PanicIntervalInMiliseconds { get; set; }
        public int DefferalCount { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public List<CardCommentModel> CardComments { get; set; }
        public CardContentModel Content { get; set; }
    }
}