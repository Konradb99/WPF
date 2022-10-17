using System.Text.Json.Serialization;

namespace WPF_Pokedex_data_access.Models
{
    public class TypeResponse
    {
        public int? id;
        public string? name;
        public int? previous;
        public List<PokemonResponse> pokemon;

        [JsonConstructor]
        public TypeResponse()
        {
        }
    }
}
