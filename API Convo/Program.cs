using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace API_Convo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            for (int i = 0; i < 10; i++)
            {
                if (i == 0 || i == 4 || i == 9)
                {
                    var kanyeResponse = client.GetStringAsync("https://api.kanye.rest").Result;

                    var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                    Console.WriteLine($"Kanye: {kanyeQuote}");
                    Console.WriteLine("==========================================================");
                }
                else if (i % 2 == 0)
                {
                    var ronResponse = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

                    var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                    Console.WriteLine($"Ron Swanson: {ronQuote}");
                    Console.WriteLine("==========================================================");
                }
            }
        }
    }
}
