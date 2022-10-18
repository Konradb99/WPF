using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex.Shared;
using WPF_Pokedex_data_access.Models;
using WPF_Pokedex_data_access.Repository;

namespace WPF_Pokedex.Views.PokemonList
{
    public class PokemonListViewModel : BindableBase
    {
        public TypeRepository _repository;
        public PokemonListViewModel(TypeRepository repository)
        {
            _repository = repository;
            Select = new TypeListEntity { name = "Normal" };
        }

        private TypeListEntity select;

        public TypeListEntity Select
        {
            get
            {
                return select;
            }
            set
            {
                select = value;
                OnPropertyChanged(nameof(Select));
            }
        }
    }
}
