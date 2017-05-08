using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationReply
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\w11_MessageRequest"))
            {
                messageQueue = new MessageQueue(@".\Private$\w11_MessageRequest");
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\w11_MessageRequest");
                messageQueue = new MessageQueue(@".\Private$\w11_MessageRequest");
            }

        }
    }
}
