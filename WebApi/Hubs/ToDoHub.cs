using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs{
    public class ToDoHub : Hub
    {
        public async Task SendToAll(string message)
        {
            await  Clients.All.SendAsync("ReceiveMessage", message);
        }
    } 
}