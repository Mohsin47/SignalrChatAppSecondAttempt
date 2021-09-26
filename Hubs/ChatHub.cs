using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrChatAppSecondAttempt.Hubs
{
    public class ChatHub:Hub
    {
        //public static List<string> ConnectedUser = new List<string>();

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendToUser(string user, string receiverConnectionId, string message)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", user, message);
        }

        //internal void UserConnectionIds(List<string> connectedUser)
        //{
        //    ConnectedUser = connectedUser;
        //}

        public string GetConnectionId() => Context.ConnectionId;







    }
}
