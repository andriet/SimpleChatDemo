using Akka.Actor;
using SimpleChat.ActorModel.Messages;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace SimpleChat.UnitTest
{
    public class ChatSystemTest : IClassFixture<ChatSystemFixture>
    {
        private ChatSystemFixture fixture;
        private readonly ITestOutputHelper output;

        public ChatSystemTest(ITestOutputHelper output, ChatSystemFixture fixture)
        {
            this.output = output;
            fixture.SetOutputHelper(output);
            fixture.Init();
            this.fixture = fixture;
        }

        [Fact]
        public void Join()
        {
            this.fixture.Client.Tell(new JoinMessage("John", ""));
            Thread.Sleep(2000);
        }
    }
}
