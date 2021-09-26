using Microsoft.AspNetCore.SignalR;
using SignalrChatAppSecondAttempt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrChatAppSecondAttempt.Hubs
{
    public class OnlineCountHub:Hub
    {
        //public static List<string> ConnectedUser = new List<string>();

        private static int Count = 0;
        public override Task OnConnectedAsync()
        {
            Count++;

            //ListUsers.UserConnectedIds.Add(Context.ConnectionId);

            //ConnectedUser.Add(Context.ConnectionId);
            //ChatHub chatHub = new ChatHub();
            //chatHub.UserConnectionIds(ConnectedUser);

            base.OnConnectedAsync();
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }


        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;

            //ListUsers.UserConnectedIds.Remove(Context.ConnectionId);


            base.OnDisconnectedAsync(exception);
            Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }
    }
}
