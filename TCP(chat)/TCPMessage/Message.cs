﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPMessage
{
    [Serializable]
    public class Message
    {
        public string Sender { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public string Date { get; set; }
    }
}
