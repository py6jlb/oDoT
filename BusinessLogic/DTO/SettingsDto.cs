using DataAccess.Entities;

namespace BusinessLogic.DTO
{
    public class SettingsDto
    {
        public SettingsDto(){}

        public SettingsDto(Settings newData){
            Id = newData.Id.ToString();
            DeadlineTimeSpanInMiliseconds = newData.DeadlineTimeSpanInMiliseconds;
            PanicTimeSpanInMiliseconds = newData.PanicTimeSpanInMiliseconds;
            StartPanicForTimeSpanInMiliseconds = newData.StartPanicForTimeSpanInMiliseconds;
        }

        public string Id {get;set;}
        public double? DeadlineTimeSpanInMiliseconds {get;set;}
        public double? PanicTimeSpanInMiliseconds {get;set;}
        public double? StartPanicForTimeSpanInMiliseconds {get;set;}
    }
}