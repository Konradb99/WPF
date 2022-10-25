using System.Text.Json.Serialization;

namespace WPF_Pokedex_data_access.Models
{
    public class Pokemon
    {
        public string? name { get; set; }
        public int? height { get; set; }
        public int? weight { get; set; }
        public Sprites? sprites { get; set; }

        public List<Stat>? stats { get; set; }

        public List<Moves>? moves { get; set; }

        [JsonConstructor]
        public Pokemon()
        {

        }
    }

    public class Sprites
    {
        public string? back_default { get; set; }
        public string? back_female { get; set; }
        public string? back_shiny { get; set; }
        public string? back_shiny_female { get; set; }
        public string? front_default { get; set; }
        public string? front_female { get; set; }
        public string? front_shiny { get; set; }
        public string? front_shiny_female { get; set; }

    }

    public class Stat
    {
        public int base_stat { get; set; }
        public int effort { get; set; }

        public Statistic stat { get; set; }
    }

    public class Statistic
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Moves
    {
        public Move move { get; set; }
    }
}
