using Akka.Actor;
using System.Collections.Generic;

namespace SimpleChat.ActorModel.Actors
{
    public class ChatChannelActor : ReceiveActor
    {
        private readonly Dictionary<string, IActorRef> contacts;
    }
}
