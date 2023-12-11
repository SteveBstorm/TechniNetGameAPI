using Microsoft.AspNetCore.SignalR;
using TechniNetGameAPI.Models;

namespace TechniNetGameAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatModel message)
        {
            await Clients.All.SendAsync("notifyNewMessage",message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await SendToGroup(groupName, new ChatModel
            {
                Username = "System",
                Message = $"Le user avec l'id : {Context.ConnectionId} vient de nous rejoindre"
            });
        }

        public async Task SendToGroup(string groupName, ChatModel message)
        {
            Clients.Group(groupName).SendAsync("notifyMessageFromGroup"+groupName, message);
        }
    }
}
