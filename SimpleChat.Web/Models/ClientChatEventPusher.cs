using System;
using SimpleChat.ActorModel.Contracts;
using Microsoft.AspNet.SignalR;

namespace SimpleChat.Web.Models
{
    /// <summary>
    /// This class is responsible for pushing events to the client
    /// </summary>
    public class ClientChatEventPusher : IChatEventsPusher
    {
        private static readonly IHubContext appHubContext;

        static ClientChatEventPusher()
        {
            appHubContext = GlobalHost.ConnectionManager.GetHubContext<AppHub>();
        }

        /// <summary>
        /// Notify the all client that a user has joined
        /// </summary>
        /// <param name="userName"></param>
        public void UserJoined(string userName)
        {
            appHubContext.Clients.All.userJoined(userName);
        }

        public void NotifyMessage(string senderName, string recipientName, string text, string connectionID)
        {
            appHubContext.Clients.Client(connectionID).notifyMessage(senderName, recipientName, text);
        }
    }
}