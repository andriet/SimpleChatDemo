using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.ActorModel.Messages
{
    public class TextMessage
    {
        public string SenderName { get; private set; }
        public string Text { get; private set; }

        public TextMessage(string senderName, string text)
        {
            this.SenderName = senderName;
            this.Text = text;
        }
    }
}
