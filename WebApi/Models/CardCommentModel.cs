using System;

namespace WebApi.Models
{
    public class CardCommentModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public long CreateDateTimeInMiliseconds { get; set; }
        public bool NotUserComment { get; set; }
    }
}