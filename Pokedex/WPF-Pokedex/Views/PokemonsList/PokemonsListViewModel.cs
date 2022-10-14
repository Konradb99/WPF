using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Pokedex.Views.PokemonsList
{
    public class PokemonsListViewModel : INotifyPropertyChanged
    {
        public PokemonsListViewModel()
        {
            PokemonName = "Pokemon";
        }

        private string _pokemonName;
        public string PokemonName
        {
            get { return _pokemonName; }
            set { _pokemonName = value; NotifyPropertyChanged(nameof(PokemonName)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
