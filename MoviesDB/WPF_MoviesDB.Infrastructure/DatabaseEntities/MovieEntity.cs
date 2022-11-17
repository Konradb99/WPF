using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MoviesDB.Infrastructure.DatabaseEntities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string release_date { get; set; }
        public double vote { get; set; }
        public string overview { get; set; }
        public string backdrop_path { get; set; }
        public string poster_path { get; set; }
    }
}
