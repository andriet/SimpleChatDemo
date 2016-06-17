﻿using Akka.Actor;
using SimpleChat.ActorModel.Contracts;
using SimpleChat.ActorModel.Messages;

namespace SimpleChat.ActorModel.Actors
{
    public class ClientActor : ReceiveActor
    {
        private readonly IChatEventsPusher chatEventPusher;
        private readonly IActorRef chatChannelController;

        public ClientActor(IChatEventsPusher chatEventPusher, IActorRef chatChannelController)
        {
            this.chatEventPusher = chatEventPusher;
            this.chatChannelController = chatChannelController;

            // Inbound message
            Receive<JoinMessage>(message =>
            {
                this.chatChannelController.Tell(message);
            });

            Receive<TextMessage>(message =>
            {
                this.chatChannelController.Tell(message);
            });

            Receive<UserStatusMessage>(message =>
            {
                this.chatEventPusher.UserJoined(message.UserName);
            });

            Receive<UpdateTextMessage>(message =>
            {
                this.chatEventPusher.NotifyMessage(message.SenderName, message.RecipientName, message.Text, message.ConnectionID);
            });
        }
    }
}
