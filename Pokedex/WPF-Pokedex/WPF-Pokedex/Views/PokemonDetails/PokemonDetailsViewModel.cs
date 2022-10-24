using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Pokedex.Shared;
using WPF_Pokedex_data_access.Models;

namespace WPF_Pokedex.Views.PokemonDetails
{
    public class PokemonDetailsViewModel : BindableBase
    {
        private readonly Navigation _navigation;

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
            }
        }

        private ICommand backButtonCommand = null;

        public ICommand BackButtonCommand
        {
            get
            {
                if (backButtonCommand == null)
                {
                    backButtonCommand = new RelayCommand(
                        () =>
                        {
                            goBackAction();
                        });
                }
                return backButtonCommand;
            }
        }

        public PokemonDetailsViewModel(Navigation navigation)
        {
            _navigation = navigation;
        }

        private void goBackAction()
        {
            _navigation.MainPanelCurrentViewModel = _navigation.PreviousViewModel;
            _navigation.PreviousViewModel = this;
        }
    }
}
