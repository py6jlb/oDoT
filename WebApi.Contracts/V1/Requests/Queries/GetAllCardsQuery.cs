using Microsoft.AspNetCore.Mvc;

namespace WebApi.Contracts.V1.Requests.Queries
{
    public class GetAllCardsQuery
    {
        [FromQuery(Name = "status")]
        public int? Status {get;set;} 
    }
}