using System;

namespace DataAccess.Entities{
    public class Settings{
        public Guid Id {get;set;}
        public double? DeadlineTimeSpanInMiliseconds {get;set;}
        public double? PanicTimeSpanInMiliseconds {get;set;}
        public double? StartPanicForTimeSpanInMiliseconds {get;set;}
    }
}