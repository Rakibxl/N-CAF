using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities.Notification;
using Microsoft.AspNetCore.SignalR;

namespace Architecture.Web.Hubs
{
    public class NotificationHub: Hub
    {
        public async Task NewMessage(NotificationInfo msg)
        {
            await Clients.All.SendAsync("MessageReceived", msg);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveSystemMessage", $"{Context.UserIdentifier} joined.");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("ReceiveSystemMessage", $"{Context.UserIdentifier} left.");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendToUser(string user, string message)
        {
            await Clients.User(user).SendAsync("ReceiveDirectMessage", $"{Context.UserIdentifier}: {message}");
        }

        public async Task Send(string message)
        {
            await Clients.All.SendAsync("ReceiveChatMessage", $"{Context.UserIdentifier}: {message}");
        }
    }
}
