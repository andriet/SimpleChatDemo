using Akka.Actor;
using SimpleChat.ActorModel.Actors;
using SimpleChat.ActorModel.Contracts;
using System;
using Xunit.Abstractions;

namespace SimpleChat.UnitTest
{
    public class ChatSystemFixture : IDisposable
    {
        private ActorSystem actorSystemInstance;
        private IActorRef chatChannelController;
        private IActorRef client;
        private IChatEventsPusher chatEventsPusher;
        private ITestOutputHelper output;

        public ChatSystemFixture()
        {
            
        }
       
        public ActorSystem ActorSystemInstance { get { return this.actorSystemInstance; } }
        public IActorRef ChatController { get { return this.chatChannelController; } }
        public IActorRef Client { get { return this.client; } }

        public void SetOutputHelper(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void Init()
        {
            this.actorSystemInstance = ActorSystem.Create("ChatSystem");
            this.chatChannelController = ActorSystemInstance.ActorOf<ChatChannelControllerActor>("ChatController");
            this.chatEventsPusher = new TestChatEventsPusher(output);
            this.client = ActorSystemInstance.ActorOf(
                Props.Create(() => new ClientActor(this.chatEventsPusher, this.chatChannelController)),
                "Client"
                );
        }

        public void Dispose()
        {
            ActorSystemInstance.Terminate();
        }
    }
}
