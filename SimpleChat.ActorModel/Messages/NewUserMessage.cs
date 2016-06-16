using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.ActorModel.Messages
{
    public class NewUserMessage
    {
        public string UserName { get; private set; }

        public NewUserMessage(string userName)
        {
            UserName = userName;
        }
    }
}
