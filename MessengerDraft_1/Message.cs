using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerDraft_1
{
    internal class Message
    {
        public string recreiverId { get; set; }
        public string senderId { get; set; }
        public string messageText { get; set; }

        public string messageId { get; set; }
        public DateTime time { get; set; }
    }
}
