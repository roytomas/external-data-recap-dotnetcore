using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FixerMovie.Models
{
    public class FixerMovieContext : DbContext
    {
        public FixerMovieContext (DbContextOptions<FixerMovieContext> options)
            : base(options)
        {
        }

        public DbSet<FixerMovie.Models.Movie> Movie { get; set; }
    }
}