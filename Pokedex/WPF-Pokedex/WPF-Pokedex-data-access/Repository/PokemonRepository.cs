using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex_data_access.Models;

namespace WPF_Pokedex_data_access.Repository
{  
    public class PokemonRepository
    {
        HttpClient client = new HttpClient();

        public async Task<Pokemon> getPokemon(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Pokemon responseResult = JsonConvert.DeserializeObject<Pokemon>(responseBody);
            responseResult.name = responseResult.name.ToUpper();
            return responseResult;
        }

        public async Task<Move> getPokemonMove(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Move move = JsonConvert.DeserializeObject<Move>(responseBody);
            return move;
        }
    }
}
