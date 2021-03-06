﻿using Akka.Actor;
using SimpleChat.ActorModel.Messages;
using System.Collections.Generic;
using System.Linq;

namespace SimpleChat.ActorModel.Actors
{
    /// <summary>
    /// This class holds the list of all users that have logged into the system.
    /// </summary>
    public class ChatChannelControllerActor : ReceiveActor
    {
        private readonly Dictionary<string, IActorRef> users;

        public ChatChannelControllerActor()
        {
            users = new Dictionary<string, IActorRef>();
            
            Receive<JoinMessage>(message => Join(message));

            Receive<TextMessage>(message => HandleText(message));

            
        }

        public List<string> GetUsers()
        {
            return users.Keys.ToList();
        }

        private void Join(JoinMessage message)
        {
            var userNeedsCreating = !users.ContainsKey(message.UserName);

            if(userNeedsCreating)
            {
                IActorRef newUser = Context.ActorOf(Props.Create(() => new UserActor(message.UserName, message.ConnectionID)), message.UserName);
                users.Add(message.UserName, newUser);
                Sender.Tell(new NewUserMessage(message.UserName));

                foreach (var user in users.Values)
                {
                    user.Tell(new RefreshUserStatusMessage(), Sender);
                }
            }
        }

        private void HandleText(TextMessage message)
        {
            users[message.RecipientName].Forward(message);
        }
    }
}
