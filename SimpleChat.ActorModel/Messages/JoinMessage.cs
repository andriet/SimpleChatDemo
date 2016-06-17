using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.ActorModel.Messages
{
    public class JoinMessage
    {
        public string UserName { get; private set; }
        public string ConnectionID { get; private set; }

        public JoinMessage(string userName, string connectionID)
        {
            UserName = userName;
            ConnectionID = connectionID;
        }
    }
}
