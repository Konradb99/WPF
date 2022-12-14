using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex.Views.PokemonDetails;
using WPF_Pokedex.Views.PokemonList;
using WPF_Pokedex.Views.TypesList;
using WPF_Pokedex_data_access.Repository;

namespace WPF_Pokedex.Shared
{
    public class MainViewModel : BindableBase
    {
        private BindableBase _TypesCurrentViewModel;

        public BindableBase TypesCurrentViewModel
        {
            get { return _TypesCurrentViewModel; }
            set
            {
                SetProperty(ref _TypesCurrentViewModel, value);
            }
        }

        public Navigation navigation { get; set; }

        public MainViewModel(TypesListViewModel typesListViewModel, Navigation nav, PokemonListViewModel pokemonListViewModel, PokemonDetailsViewModel pokemonDetailsViewModel)
        {
            TypesCurrentViewModel = typesListViewModel;
            navigation = nav;
            navigation.MainPanelCurrentViewModel = pokemonListViewModel;
            navigation.PreviousViewModel = pokemonDetailsViewModel;
        }
    }
}
