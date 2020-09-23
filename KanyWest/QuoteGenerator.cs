using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace KanyWest
{
    public class QuoteGenerator
    {
        public QuoteGenerator(HttpClient client)
        {
            _client = client;
        }
        public string kanyeURL = "https://api.kanye.rest";
        public HttpClient _client = new HttpClient();

        public string GetKanyeQuote()
        {
            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;

            return JObject.Parse(kanyeResponse).GetValue("quote").ToString();
        }



    }



    
}
