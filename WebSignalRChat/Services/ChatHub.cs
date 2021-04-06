using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebSignalRChat.Services
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessagePrivado(string user, string message, string destinoId)
        {
            await Clients.User(destinoId).SendAsync("ReceiveMessage", user, message);
        }
    }
}
