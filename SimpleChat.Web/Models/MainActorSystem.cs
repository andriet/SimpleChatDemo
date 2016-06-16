using Akka.Actor;
using SimpleChat.ActorModel.Actors;
using SimpleChat.ActorModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChat.Web.Models
{
    public static class MainActorSystem
    {
        private static ActorSystem actorSystem;
        private static IChatEventsPusher chatEventsPusher;

        public static void Create()
        {
            chatEventsPusher = new ClientChatEventPusher();
            actorSystem = ActorSystem.Create("ChatSystem");
            ActorReferences.ChatChannelController = actorSystem.ActorOf<ChatChannelControllerActor>();
            ActorReferences.Client = actorSystem.ActorOf(
                Props.Create(() => new ClientActor(chatEventsPusher, ActorReferences.ChatChannelController)),
                "Client"
                );
        }

        public static void Shutdown()
        {
            if(actorSystem != null)
            {
                actorSystem.Terminate();
            }
        }

        public static class ActorReferences
        {
            public static IActorRef ChatChannelController { get; set; }
            public static IActorRef Client { get; set; }
        }
    }
}