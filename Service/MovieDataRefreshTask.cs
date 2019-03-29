using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FixerMovie.Models;
namespace FixerMovie.Service
{
    // uses https://theysaidso.com/api/
    public class MovieDataRefreshTask : IScheduledTask
    {
        public string Schedule => "* */6 * * *";
        
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();

            var json = JObject.Parse(await httpClient.GetStringAsync("https://api.themoviedb.org/3/movie/3?api_key=7f7a8c1e4a67c553b035910c9db1844e&language=en-US"));

            var movieData = JsonConvert.DeserializeObject<Movie>(json.ToString());
        }
    }
    
    // public class QuoteOfTheDay
    // {
    //     public static QuoteOfTheDay Current { get; set; }

    //     static QuoteOfTheDay()
    //     {
    //         Current = new QuoteOfTheDay { Quote = "No quote", Author = "Maarten" };
    //     }
        
    //     public string Quote { get; set; }
    //     public string Author { get; set; }
    // }
}