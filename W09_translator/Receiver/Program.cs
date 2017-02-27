using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\W09_QueryReceiver"))
            {
                messageQueue = new MessageQueue(@".\Private$\W09_QueryReceiver");
                messageQueue.Label = "Testing Queue receiver";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\W09_QueryReceiver");
                messageQueue = new MessageQueue(@".\Private$\W09_QueryReceiver");
                messageQueue.Label = "Newly Created Queue receiver";
            }

            while (true)
            {
                System.Messaging.Message m = messageQueue.Receive();
                m.Formatter = new System.Messaging.XmlMessageFormatter(new Type[1] { typeof(string) });

                String output = (String) m.Body;
                Console.WriteLine("Output: "+output);
            }
        }
    }
}
