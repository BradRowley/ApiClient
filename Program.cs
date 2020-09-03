using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiClient
{
    class Jokes
    {
        [JsonPropertyName("setup")]
        public string Setup { get; set; }

        [JsonPropertyName("punchline")]
        public string Punchline { get; set; }

    }


    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/random");
            var result = await JsonSerializer.DeserializeAsync<Jokes>(responseAsStream);
            var hasQuitTheApplication = false;
            while (hasQuitTheApplication == false)
            {
                Console.WriteLine("Would you like to hear a joke? YES or NO:  ");
                var answer = Console.ReadLine();
                if (answer == "YES")
                {
                    Console.WriteLine(result.Setup);
                    Console.WriteLine(result.Punchline);

                }
                else
                {
                    hasQuitTheApplication = true;
                }


                // https://quote-garden.herokuapp.com/api/v2/quotes/random
                // var responseAsStream = await client.GetStreamAsync("https://official-joke-api.appspot.com/jokes/random");
                // var result = await JsonSerializer.DeserializeAsync<Jokes>(responseAsStream);

                // Console.WriteLine(result.Joke);
            }
            Console.WriteLine("Goodbye");
        }
    }
}
