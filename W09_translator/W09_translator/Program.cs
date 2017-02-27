using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Threading;

namespace W09_translator
{
    
    class Program
    {
        static void Main(string[] args)
        {
            while (
                    (!MessageQueue.Exists(@".\Private$\W09_QuerySender")) ||
                    (!MessageQueue.Exists(@".\Private$\W09_QueryReceiver"))
                  )
            {
                Thread.Sleep(2000);
            };
            MessageQueue messageQueueSender = new MessageQueue(@".\Private$\W09_QuerySender");
            messageQueueSender.Label = "Testing Queue for sending";

            MessageQueue messageQueueReceiver = new MessageQueue(@".\Private$\W09_QueryReceiver");
            messageQueueReceiver.Label = "Testing Queue receiver";

            while (true)
            {
                System.Messaging.Message m = messageQueueSender.Receive();
                m.Formatter = new System.Messaging.XmlMessageFormatter(new Type[1] { typeof(string) });

                String input = (String) m.Body;
                input = input.ToUpper();
                messageQueueReceiver.Send(input, "message");

                Console.WriteLine(DateTime.Now.ToString()+" message translated.");
            }

        }
    }
}
