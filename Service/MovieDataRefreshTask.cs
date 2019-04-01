using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FixerMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace FixerMovie.Service
{
    public class MovieDataRefreshTask : IScheduledTask
    {
         private readonly FixerMovieContext _context;
        public string Schedule => "* */6 * * *";   
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();
            int movielistCount = 10; 

            for(int i = 1; i<movielistCount;i++){
               var json = JObject.Parse(await httpClient.GetStringAsync("https://api.themoviedb.org/3/list/"+i.ToString()+"?api_key=7f7a8c1e4a67c553b035910c9db1844e&language=en-US"));
               MovieData.Current.AddRange(JsonConvert.DeserializeObject<List<Movie>>(json["items"].ToString()));              
            }
            SeedData.Initialize();
        }
    }

    public class MovieData
    {
        public static List<Movie> Current { get; set; }

        static MovieData()
        {
            Current = new List<Movie>();
        }
    }
}