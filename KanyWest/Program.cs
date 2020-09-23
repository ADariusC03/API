using System;
using System.Net.Http;

namespace KanyWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var qGenerator = new QuoteGenerator(client);

            var kanyeQuote = qGenerator.GetKanyeQuote();

            Console.WriteLine(kanyeQuote);
        }
    }
}
