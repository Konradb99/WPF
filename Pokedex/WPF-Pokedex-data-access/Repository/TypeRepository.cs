using Newtonsoft.Json;
using WPF_Pokedex_data_access.Models;

namespace WPF_Pokedex_data_access.Repository
{
    public class TypeRepository : ITypeRepository
    {
        string baseUri = "https://pokeapi.co/api/v2/type";
        HttpClient client = new HttpClient();

        public async Task<List<TypeListEntity>> getTypes()
        {
            HttpResponseMessage response = await client.GetAsync(baseUri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            TypeListResponse responseResult = JsonConvert.DeserializeObject<TypeListResponse>(responseBody);
            foreach(var obj in responseResult.results)
            {
                obj.name = $"{obj.name[0].ToString().ToUpper()}{obj.name.Substring(1)}";
            }
            return responseResult.results;
        }
    }
}
