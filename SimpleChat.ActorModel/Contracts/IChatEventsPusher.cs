using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.ActorModel.Contracts
{
    public interface IChatEventsPusher
    {
        void UserJoined(string userName);
    }
}
