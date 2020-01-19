using System;

namespace DataAccess.Entities{
    public class CardComment{
        public Guid Id {get;set;}
        public string Text {get;set;}
        public DateTime CreateDateTime {get;set;}
        public bool NotUserComment {get;set;}
    }
}