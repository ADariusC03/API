using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace PlayingWithAPIs
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var client = new HttpClient();

            //RandomBeer
            var randomBeerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beer/random/?key=310c54f087e85862c1980e152c1cdf10").Result;
            JToken rBeer = JToken.Parse(randomBeerResponse);
            var rBeerName = (string)rBeer.SelectToken("data.name").ToString();

            Console.WriteLine("====================================");
            Console.WriteLine("RANDOM NAME");
            Console.WriteLine();
            Console.WriteLine(rBeerName);
            Console.WriteLine("=====================================");

            //BeerList
            var beerResponse = client.GetStringAsync("http://api.brewerydb.com/v2/beers/?key=310c54f087e85862c1980e152c1cdf10").Result;

            var Beers = JsonConvert.DeserializeObject<BeerList>(beerResponse);

            foreach (var b in Beers.data)
            {
                Console.WriteLine($"Name: {b.name} ID: {b.id}");

            }

            

        }
    }
}
