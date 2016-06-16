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
        public void Join(string userName)
        {
            MainActorSystem
                .ActorReferences
                .Client
                .Tell(new JoinMessage(userName));
        }
    }
}