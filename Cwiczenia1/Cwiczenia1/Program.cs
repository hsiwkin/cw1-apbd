using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenia1
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl/");

            if (result.IsSuccessStatusCode) // 2xx
            {
                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);

                MatchCollection matches = regex.Matches(html);

                foreach(var match in matches)
                {
                    Console.WriteLine(match.ToString());
                }
                
            }

            Console.WriteLine("Koniec!");
        }
    }
}
