﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.ActorModel.Messages
{
    public class UserStatusMessage
    {
        public string UserName { get; private set; }

        public UserStatusMessage(string userName)
        {
            UserName = userName;
        }
    }
}
