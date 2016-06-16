using Akka.Actor;
using SimpleChat.ActorModel.Messages;

namespace SimpleChat.ActorModel.Actors
{
    public class UserActor : ReceiveActor
    {
        private readonly string name;

        public UserActor(string name)
        {
            this.name = name;

            Receive<RefreshUserStatusMessage>(
                message =>
                {
                    Sender.Tell(new UserStatusMessage(this.name));
                });
        }
    }
}
