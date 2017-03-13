using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChannelMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Thread.Sleep(5000);
                Console.Clear();
                Console.WriteLine("Channel Moniter");
                if (MessageQueue.Exists(@".\Private$\w10_InvalidMessageChannel"))
                {
                    MessageQueue messageQueue = new MessageQueue(@".\Private$\w10_InvalidMessageChannel");
                    Console.WriteLine(messageQueue.GetAllMessages().Count());

                }


            }
        }
    }
}
