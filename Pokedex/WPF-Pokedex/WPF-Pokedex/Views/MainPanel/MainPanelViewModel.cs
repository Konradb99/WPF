using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex.Shared;
using WPF_Pokedex.Views.PokemonList;

namespace WPF_Pokedex.Views.MainPanel
{
    public class MainPanelViewModel : BindableBase
    {
        private BindableBase _PokemonCurrentViewModel;

        public BindableBase PokemonCurrentViewModel
        {
            get { return _PokemonCurrentViewModel; }
            set
            {
                SetProperty(ref _PokemonCurrentViewModel, value);
            }
        }

        public MainPanelViewModel(PokemonListViewModel pokemonListViewModel)
        {
            PokemonCurrentViewModel = pokemonListViewModel;
        }
    }
}
