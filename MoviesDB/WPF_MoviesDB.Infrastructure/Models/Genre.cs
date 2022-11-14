using System.Text.Json.Serialization;

namespace WPF_MoviesDB.Infrastructure.Models
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }

        [JsonConstructor]
        public Genre()
        {
        }
    }

    public class GenreList
    {
        public IEnumerable<Genre> genres { get; set; }

        [JsonConstructor]
        public GenreList()
        {
        }
    }
}