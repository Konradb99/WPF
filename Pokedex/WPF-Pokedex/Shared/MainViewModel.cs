using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Pokedex.Views.TypesList;

namespace WPF_Pokedex.Shared
{
    public class MainViewModel : BindableBase
    {
        private TypesListViewModel _typesListViewModel = new TypesListViewModel();

        private BindableBase _TypesCurrentViewModel;

        public BindableBase TypesCurrentViewModel
        {
            get { return _TypesCurrentViewModel; }
            set
            {
                SetProperty(ref _TypesCurrentViewModel, value);
            }
        }

        public MainViewModel()
        {
            TypesCurrentViewModel = _typesListViewModel;
        }
    }
}
