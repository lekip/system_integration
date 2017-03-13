using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ChannelReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\w10_MessageChannel"))
            {
                messageQueue = new MessageQueue(@".\Private$\w10_MessageChannel");
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\w10_MessageChannel");
                messageQueue = new MessageQueue(@".\Private$\w10_MessageChannel");
            }

            while (true)
            {
                System.Messaging.Message m = messageQueue.Receive();
                m.Formatter = new System.Messaging.XmlMessageFormatter(new Type[1] { typeof(string) });

                String output = (String)m.Body;

                if (output.Contains('2'))
                {
                    Console.WriteLine("Ugyldig besked modtaget");
                    MessageQueue invalidMessageQueue = new MessageQueue(@".\Private$\w10_InvalidMessageChannel");
                    invalidMessageQueue.Send(output, "Title");
                }
                else
                {
                    Console.WriteLine("Modtaget: " + output);
                }
            }
        }
    }
}
