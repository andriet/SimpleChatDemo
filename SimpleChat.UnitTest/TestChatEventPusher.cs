using SimpleChat.ActorModel.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace SimpleChat.UnitTest
{
    public class TestChatEventsPusher : IChatEventsPusher
    {
        private ITestOutputHelper output;

        public TestChatEventsPusher(ITestOutputHelper output)
        {
            this.output = output;
        }

        public void NotifyMessage(string senderName, string recipientName, string text, string connectionID)
        {
            throw new NotImplementedException();
        }

        public void UserJoined(string userName)
        {
            output.WriteLine($"{userName} has joined.");
        }
    }
}
