using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex.Shared;
using WPF_Pokedex.Views.MainPanel;
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

        public PokemonListViewModel(TypeRepository typeRepository, PokemonRepository pokemonRepository)
        {
            _typeRepository = typeRepository;
            _pokemonRepository = pokemonRepository;
        }

        private TypeListEntity _selectedPokemon;
        public TypeListEntity SelectedPokemon
        {
            get
            {
                return _selectedPokemon;
            }
            set
            {
                _selectedPokemon = value;
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

        public async void LoadPokemons(string url)
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
