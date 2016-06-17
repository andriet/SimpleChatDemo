using Akka.Actor;
using SimpleChat.ActorModel.Messages;

namespace SimpleChat.ActorModel.Actors
{
    public class UserActor : ReceiveActor
    {
        private readonly string name;
        private readonly string connectionID;

        public UserActor(string name, string connectionID)
        {
            this.name = name;
            this.connectionID = connectionID;

            Receive<RefreshUserStatusMessage>(
                message =>
                {
                    Sender.Tell(new UserStatusMessage(this.name));
                });

            Receive<TextMessage>(message => HandleText(message));
        }

        private void HandleText(TextMessage message)
        {
            Sender.Tell(new UpdateTextMessage(message.SenderName, message.RecipientName, message.Text, this.connectionID));
        }
    }
}
