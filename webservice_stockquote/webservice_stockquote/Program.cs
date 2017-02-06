using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webservice_stockquote
{
    class Program
    {
        static void Main(string[] args)
        {
            String k = "";
            while (k != "2")
            {
                Console.Clear();
                Console.WriteLine("Menu\n\n");
                Console.WriteLine("1) Læs kurs for BP");
                Console.WriteLine("2) Afslut");
                k = Console.ReadKey().KeyChar.ToString();
                Console.Clear();
                if (k == "1")
                {
                    stock.StockQuoteSoapClient client = new stock.StockQuoteSoapClient("StockQuoteSoap");
                    Console.WriteLine(client.GetQuote("BP"));
                    Console.ReadLine();
                }
            }
        }
    }
}
