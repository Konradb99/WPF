using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Pokedex_data_access.Models;
using WPF_Pokedex_data_access.Repository;

namespace WPF_Pokedex.TypeList
{
    public class TypeListViewModel : INotifyPropertyChanged
    {
        ITypeRepository _repository = new TypeRepository();

        public event PropertyChangedEventHandler PropertyChanged;
        public TypeListViewModel()
        {
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
                //Types.Remove(value);
            }
        }

        private void OnChange()
        {
            types.Remove(_selectedType);
        }

        private ObservableCollection<TypeListEntity> types;
        public ObservableCollection<TypeListEntity> Types
        {
            get { return types; }
            set
            {
                if (types != value)
                {
                    types = value;
                    NotifyPropertyChanged("Types");
                }
            }
        }

        private async void LoadData()
        {
            var TypesList = await _repository.getTypes();
            Types = new ObservableCollection<TypeListEntity>(TypesList);
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
