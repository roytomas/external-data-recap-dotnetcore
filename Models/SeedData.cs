using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using FixerMovie.Service;
using Microsoft.Extensions.Logging;
namespace FixerMovie.Models
{
    public class SeedData
    {
        public static void Initialize()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FixerMovieContext>();
            optionsBuilder.UseSqlite("Data Source=FixerMovie.db");
           
            using (var context = new FixerMovieContext(optionsBuilder.Options))
            {
            // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                MovieData.Current.ForEach(f=>{
                    var movie = context.Movie.FindAsync(f.id);
                    if(movie.Result == null){    
                        f.poster_path = f.poster_path != null ? "https://image.tmdb.org/t/p/w500"+f.poster_path : "";              
                        context.Movie.Add(f);
                    }
                });
                
                context.SaveChanges();
            }
                   
        }
    }
}