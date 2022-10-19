using System.Text.Json.Serialization;

namespace WPF_Pokedex_data_access.Models
{
    public class Pokemon
    {
        public string? name { get; set; }
        public int? height { get; set; }
        public int? weight { get; set; }
        public Sprites? sprites { get; set; }

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
}
