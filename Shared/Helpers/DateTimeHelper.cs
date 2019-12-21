using System;

namespace Shared.Helpers{
    public static class DateTimeHelper{
        public static double? ConverToMilisecond(DateTime? value){
            if(value.HasValue){
                return value.Value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            }else{
                return null;
            }
            
        }

        public static DateTime? MilisecondToDateTime(double? value){
            if(value.HasValue){
                return (new DateTime(1970, 1, 1)).AddMilliseconds(value.Value);
            }else{
                return null;
            }            
        }
    }
}