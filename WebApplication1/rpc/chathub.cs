using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.rpc
{
    public class NotificationHub : Hub
    {
        // Client can call this method (RPC) 
        public async Task SendMessage(string user, string message)
        {
            // Server calls a method on all connected clients
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
