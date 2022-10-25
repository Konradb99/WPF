using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Pokedex_data_access.Models
{
    public class Move
    {
        public string name { get; set; }
        public string url { get; set; }
        public int? accurancy { get; set; }
        public int? power { get; set; }
        public int? pp { get; set; }
    }
}
