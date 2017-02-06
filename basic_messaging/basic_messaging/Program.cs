using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace basic_messaging
{
    class Program
    {
        static void Main(string[] args)
        {

            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\SomeTestName"))
            {
                messageQueue = new MessageQueue(@".\Private$\SomeTestName");
                messageQueue.Label = "Testing Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\SomeTestName");
                messageQueue = new MessageQueue(@".\Private$\SomeTestName");
                messageQueue.Label = "Newly Created Queue";
            }


            String k = "";
            while (k!="4")
            {
                Console.Clear();

                Console.WriteLine("Menu\n\n");
                Console.WriteLine("1) Læs");
                Console.WriteLine("2) Opret");
                Console.WriteLine("3) Ryd message liste");
                Console.WriteLine("\n4) Afslut");

                k = Console.ReadKey().KeyChar.ToString();
                Console.Clear();


                if (k == "1")
                {
                    Console.WriteLine("Alle beskeder:\n\n");
                    System.Messaging.Message[] messages = messageQueue.GetAllMessages();

                    foreach (System.Messaging.Message message in messages)
                    {
                        Console.WriteLine(message.Body.ToString());
                    }
                    Console.ReadLine();
                };

                if (k == "2")
                {
                    Console.Write("Indtast besked: ");
                    String m = Console.ReadLine();
                    messageQueue.Send(m, "Title");
                };

                if (k == "3")
                {
                    messageQueue.Purge();
                };

            }

        }
    }
}
