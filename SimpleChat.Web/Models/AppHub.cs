using Akka.Actor;
using Microsoft.AspNet.SignalR;
using SimpleChat.ActorModel.Messages;

namespace SimpleChat.Web.Models
{
    /// <summary>
    /// This class is responsible for receiving message from the javascript client
    /// </summary>
    public class AppHub : Hub
    {
        public void Join(string userName, string connectionID)
        {
            MainActorSystem
                .ActorReferences
                .Client
                .Tell(new JoinMessage(userName, connectionID));
        }

        public void SendMessage(string senderName, string recipientName, string text, string connectionID)
        {
            MainActorSystem
                .ActorReferences
                .Client
                .Tell(new TextMessage(senderName, recipientName, text));
        }
    }
}