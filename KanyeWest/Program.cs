using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeWest
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                KanyeQuote();
                Console.WriteLine();
                RonQuote();
                Console.WriteLine();
                ChuckQuote();
                Console.ReadLine();
            }
        }
        public static void KanyeQuote()
        {
            //API url
            string kanyeURL = " https://api.kanye.rest";

            //Allows us to call API
            using (HttpClient client = new HttpClient())
            {
                //Stores the JSON response in a variable
                string kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                //Parses through the response we received to get value associated with the NAME quote
                string kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

                Console.WriteLine($"Kanye: {kanyeQuote}");
            }
        }

        public static void RonQuote()
        {
            //Ron Swanson Url
            string ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            using (HttpClient client = new HttpClient())
            {
                string ronResponse = client.GetStringAsync(ronURL).Result;

                string ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

                Console.WriteLine($"Ron Swanson: {ronQuote}");
            }
        }

        public static void ChuckQuote()
        {
            string chuckURL = "https://api.chucknorris.io/jokes/random";

            using (HttpClient client = new HttpClient())
            {
                string chuckResponse = client.GetStringAsync(chuckURL).Result;

                string chuckQuote = JObject.Parse(chuckResponse).GetValue("value").ToString();

                Console.WriteLine($"Chuck Norris: {chuckQuote}");
            }
        }




    }
}
