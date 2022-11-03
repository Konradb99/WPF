using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MoviesDB.Infrastructure.Models
{
    public class Movie
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public ICollection<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class MoviePage
    {
        public int page { get; set; }
        public IEnumerable<Movie> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
