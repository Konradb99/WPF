using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Pokedex_data_access.Models
{
    public class PokemonResponse
    {
        public PokemonListEntity pokemon;
        public int slot;

        [JsonConstructor]
        public PokemonResponse()
        {

        }
    }
}
