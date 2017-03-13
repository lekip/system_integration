using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ChannelSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Channel sender");
            String s = "";
            while (s != "exit") { 

            Console.Write("Indtast besked: ");
            s = Console.ReadLine();
                if (s != "exit")
                {
                    MessageQueue messageQueue = new MessageQueue(@".\Private$\w10_MessageChannel");
                    messageQueue.Send(s, "Title");
                }            
            }            
        }
    }
}
