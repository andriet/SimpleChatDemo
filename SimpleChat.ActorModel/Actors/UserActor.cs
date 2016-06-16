using Akka.Actor;

namespace SimpleChat.ActorModel.Actors
{
    public class UserActor : ReceiveActor
    {
        private readonly string name;

        public UserActor(string name)
        {
            this.name = name;
        }
    }
}
