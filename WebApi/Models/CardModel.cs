using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long CreateDateTimeInMiliseconds { get; set; }
        public long? DeadLineDateTimeInMiliseconds { get; set; }
        public long? StartPanicDateTimeInMiliseconds { get; set; }
        public long? PanicIntervalInMiliseconds { get; set; }
        public long? DoNotDisturbInMiliseconds { get; set; }
        public int DefferalCount { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public List<CardCommentModel> CardComments { get; set; }
        public CardContentModel Content { get; set; }
    }
}