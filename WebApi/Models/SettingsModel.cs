using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class SettingsModel
    {
        public string Id {get;set;}
        public double? DeadlineTimeSpanInMiliseconds {get;set;}
        public double? PanicTimeSpanInMiliseconds {get;set;}
        public double? StartPanicForTimeSpanInMiliseconds {get;set;}
    }
}