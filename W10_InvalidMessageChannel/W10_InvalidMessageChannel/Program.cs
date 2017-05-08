using CommonClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace W10_InvalidMessageChannel
{
    class Program
    {
        static void Main(string[] args)
        {
            String k = "";
            while (k != "2")
            {
                Console.WriteLine("Channel setup\n\n");
                Console.WriteLine("1) Rewrite channels");
                Console.WriteLine("2) Exit");

                k = Console.ReadKey().KeyChar.ToString();
                Console.Clear();

                if (k == "1")
                {
                    if (MessageQueue.Exists(@".\Private$\w10_MessageChannel"))
                    {
                        MessageQueue.Delete(@".\Private$\w10_MessageChannel");
                    }

                    if (MessageQueue.Exists(@".\Private$\w10_InvalidMessageChannel"))
                    {
                        MessageQueue.Delete(@".\Private$\w10_InvalidMessageChannel");
                    }                    

                    // Create the Queue
                    MessageQueue mc = MessageQueue.Create(@".\Private$\w10_MessageChannel");
                    mc.Formatter = new XmlMessageFormatter(new Type[] { typeof(WebArticle) });

                    // Create the Queue
                    MessageQueue imc = MessageQueue.Create(@".\Private$\w10_InvalidMessageChannel");
                    imc.Formatter = new XmlMessageFormatter(new Type[] { typeof(WebArticle) });

                    Console.WriteLine("Channels created");
                    Console.ReadKey();
                }
            }                
        }
    }
}
