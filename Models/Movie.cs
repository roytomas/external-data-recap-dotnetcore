using System;
using System.ComponentModel.DataAnnotations;

namespace FixerMovie.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; }

        public string original_title{get; set;}
        public string imdb_id{ get; set;}

        [DataType(DataType.Date)]
        public DateTime release_date { get; set; }
        public string status { get; set; }

        public double popularity {get; set;}

        public string poster_path{ get; set;}
        public int revenue {get; set;}

        public decimal price {get; set;}
        public int runtime{ get; set;}
        
        public string overview { get; set; }
    }
}