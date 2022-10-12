using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_Pokedex_data_access.Models;
using WPF_Pokedex_data_access.Repository;

namespace WPF_Pokedex.TypeList
{
    public class TypeListViewModel : INotifyPropertyChanged
    {
        ITypeRepository _repository = new TypeRepository();

        private ObservableCollection<TypeListEntity> types;
        public ObservableCollection<TypeListEntity> Types
        {
            get { return types; }
            set
            {
                if (this.types != value)
                {
                    this.types = value;
                    this.NotifyPropertyChanged("Types");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public TypeListViewModel()
        {
            Types = new ObservableCollection<TypeListEntity>() {
                new TypeListEntity { name = "Normal" },
                new TypeListEntity { name = "Dark" },
                new TypeListEntity { name = "Grass" },
                new TypeListEntity { name = "Water" }
            };
            LoadData();
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
