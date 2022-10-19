using System;
using System.Collections.ObjectModel;
using WPF_Pokedex.Shared;
using WPF_Pokedex.Views.PokemonList;
using WPF_Pokedex_data_access.Models;
using WPF_Pokedex_data_access.Repository;

namespace WPF_Pokedex.Views.TypesList
{
    public class TypesListViewModel : BindableBase
    {
        TypeRepository _repository;
        PokemonListViewModel _pokemonListViewModel;

        public TypesListViewModel(TypeRepository repository, PokemonListViewModel pokemonListViewModel)
        {
            _repository = repository;
            _pokemonListViewModel = pokemonListViewModel;
            LoadData();
        }
        private TypeListEntity _selectedType;
        public TypeListEntity SelectedType
        {
            get
            {
                return _selectedType;
            }
            set
            {
                _selectedType = value;
                _pokemonListViewModel.LoadPokemons(_selectedType.url);
            }
        }
        

        private ObservableCollection<TypeListEntity> types = new ObservableCollection<TypeListEntity>();
        public ObservableCollection<TypeListEntity> Types
        {
            get { return types; }
            set
            {
                types = value;
            }
        }

        private async void LoadData()
        {
            var TypesList = await _repository.getTypes();
            foreach(var type in TypesList)
            {
                types.Add(type);
            }
        }
    }
}
