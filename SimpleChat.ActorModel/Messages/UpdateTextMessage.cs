using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.ActorModel.Messages
{
    public class UpdateTextMessage
    {
        public string SenderName { get; private set; }
        public string RecipientName { get; private set; }
        public string Text { get; private set; }
        public string ConnectionID { get; private set; }

        public UpdateTextMessage(string senderName, string recipientName, string text, string connectionID)
        {
            this.SenderName = senderName;
            this.RecipientName = recipientName;
            this.Text = text;
            this.ConnectionID = connectionID;
        }
    }
}
