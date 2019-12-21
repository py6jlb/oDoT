using System;
using System.Collections.Generic;

namespace DataAccess.Entities{
    public class Card{
        public Guid Id {get;set;}
        public string Name {get;set;}
        public DateTime CreateDateTime {get;set;}
        public DateTime? DeadLineDateTime {get;set;}
        public DateTime? StartPanicDateTime {get;set;}
        public double? PanicIntervalInMiliseconds {get;set;}
        public double? DoNotDisturbInMiliseconds {get;set;}
        public int DefferalCount {get;set;}
        public int Status {get;set;}
        public int Priority {get;set;}
        public List<CardComment> CardComments {get;set;}
        public CardContent Content {get;set;}
    }
}