using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex.Shared;
using WPF_Pokedex.Views.PokemonDetails;
using WPF_Pokedex.Views.TypesList;
using WPF_Pokedex_data_access.Models;
using WPF_Pokedex_data_access.Repository;

namespace WPF_Pokedex.Views.PokemonList
{
    public class PokemonListViewModel : BindableBase
    {
        public TypeRepository _typeRepository;
        private PokemonRepository _pokemonRepository;
        private readonly Navigation _navigation;
        private readonly PokemonDetailsViewModel _pokemonDetailsViewModel;

        public PokemonListViewModel(TypeRepository typeRepository, PokemonRepository pokemonRepository, Navigation navigation, PokemonDetailsViewModel pokemonDetailsViewModel)
        {
            _typeRepository = typeRepository;
            _pokemonRepository = pokemonRepository;
            _navigation = navigation;
            _pokemonDetailsViewModel = pokemonDetailsViewModel;
        }

        private Pokemon _selectedPokemon;
        public Pokemon SelectedPokemon
        {
            get
            {
                return _selectedPokemon;
            }
            set
            {
                _selectedPokemon = value;
                _pokemonDetailsViewModel.SelectedPokemon = value;          
                _navigation.MainPanelCurrentViewModel = _navigation.PreviousViewModel;
                _navigation.PreviousViewModel = this;
            }
        }

        private ObservableCollection<Pokemon> pokemons = new ObservableCollection<Pokemon>();

        public ObservableCollection<Pokemon> Pokemons
        {
            get
            {
                return pokemons;
            }
            set
            {
                pokemons = value;
                OnPropertyChanged(nameof(Pokemons));
            }
        }

        public async void LoadPokemons(string url, PokemonDetailsViewModel previous)
        {
            var pokemonResponse = await _typeRepository.getTypePokemons(url);
            Pokemons = new ObservableCollection<Pokemon>();

            foreach (var item in pokemonResponse)
            {
                Pokemon pokemon = await _pokemonRepository.getPokemon(item.pokemon.url);
                Pokemons.Add(pokemon);
            }
        }
    }
}
