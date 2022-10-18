using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WPF_Pokedex_data_access.Models
{
    public class TypeListResponse
    {
        public int? count;
        public int? next;
        public int? previous;
        public List<TypeListEntity> results;

        [JsonConstructor]
        public TypeListResponse()
        {
        }
    }
}
