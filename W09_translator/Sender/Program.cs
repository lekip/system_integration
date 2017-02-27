using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\W09_QuerySender"))
            {
                messageQueue = new MessageQueue(@".\Private$\W09_QuerySender");
                messageQueue.Label = "Testing Queue for sending";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\W09_QuerySender");
                messageQueue = new MessageQueue(@".\Private$\W09_QuerySender");
                messageQueue.Label = "Newly Created Queue for sending";
            }

            String input="";
            while (input != "exit")
            {
                Console.Write("Enter message:");
                input = Console.ReadLine();
                Console.WriteLine();
                messageQueue.Send(input, "message");
            }

        }
    }
}
