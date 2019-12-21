using System;

namespace DataAccess.Entities{
    public class GlobalUserParameters{
        public Guid Id {get;set;}
        public DateTime? GlobalDeadLineDateTime {get;set;}
        public DateTime? GlobalStartPanicDateTime {get;set;}
        public long? GlobalPanicIntervalInMiliseconds {get;set;}
        public long? GlobalDoNotDisturbInMiliseconds {get;set;}
    }
}