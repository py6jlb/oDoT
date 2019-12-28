using DataAccess.Entities;

namespace BusinessLogic.DTO
{
    public class SettingsDto
    {
        public string Id {get;set;}
        public double? DeadlineTimeSpanInMiliseconds {get;set;}
        public double? PanicTimeSpanInMiliseconds {get;set;}
        public double? DoNotDisturbTimeSpanInMiliseconds {get;set;}
        public double? StartPanicForTimeSpanInMiliseconds {get;set;}
    }
}