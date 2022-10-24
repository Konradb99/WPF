using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex.Views.PokemonDetails;
using WPF_Pokedex.Views.PokemonList;

namespace WPF_Pokedex.Shared
{
    public class Navigation : BindableBase
    {
        private BindableBase _MainPanelCurrentViewModel;
        private BindableBase _PreviousViewModel;

        public BindableBase MainPanelCurrentViewModel
        {
            get 
            { 
                return _MainPanelCurrentViewModel; 
            }
            set
            {
                SetProperty(ref _MainPanelCurrentViewModel, value);
            }
        }

        public BindableBase PreviousViewModel
        {
            get
            {
                return _PreviousViewModel;
            }
            set
            {
                SetProperty(ref _PreviousViewModel, value);
            }
        }

        public Navigation()
        {
        }
    }
}
