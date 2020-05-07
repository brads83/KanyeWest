using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;

namespace KanyeWest
{
    public class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i < 5; i++)
            {
                KanyeQuote();
                RonQuote();
                ChuckQuote();
            }
        }
        public static void KanyeQuote()
        {
            //API url
            var kanyeURL = " https://api.kanye.rest";

            //Allows us to call API
            var client = new HttpClient();

            //Stores the JSON response in a variable
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

            //Parses through the response we received to get value associated with the NAME quote
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            Console.WriteLine($"Kanye: {kanyeQuote}");
        }

        public static void RonQuote()
        {
            //Ron Swanson Url
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var client = new HttpClient();

            var ronResponse = client.GetStringAsync(ronURL).Result;

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            Console.WriteLine($"Ron Swanson: {ronQuote}");
        }
        
        public static void ChuckQuote()
        {
            var chuckURL = "https://api.chucknorris.io/jokes/random";

            var client = new HttpClient();

            var chuckResponse = client.GetStringAsync(chuckURL).Result;

            var chuckQuote = JObject.Parse(chuckResponse).GetValue("value").ToString();

            Console.WriteLine($"Chuck Norris: {chuckQuote}");
        }



        
    }
}
