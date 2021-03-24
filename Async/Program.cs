using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.dotnetfoundation.org";
            int count = 500;

            //Console.WriteLine(GetHtmlAsync(url).Result);
            Console.WriteLine(GetFirstCharactersCountAsync(url, count).Result);

            Console.ReadLine();
        }

        public static Task<string> GetHtmlAsync(string url)
        {
            // Execution is synchronous here
            var client = new HttpClient();

            return client.GetStringAsync(url);
        }

        public static async Task<string> GetFirstCharactersCountAsync(string url, int count)
        {
            // Execution is synchronous here
            var client = new HttpClient();

            // Execution of GetFirstCharactersCountAsync() is yielded to the caller here
            // GetStringAsync returns a Task<string>, which is *awaited*
            var page = await client.GetStringAsync("https://www.dotnetfoundation.org");

            // Execution resumes when the client.GetStringAsync task completes,
            // becoming synchronous again.

            if (count > page.Length)
            {
                return page;
            }
            else
            {
                return page.Substring(0, count);
            }
        }
    }
}
