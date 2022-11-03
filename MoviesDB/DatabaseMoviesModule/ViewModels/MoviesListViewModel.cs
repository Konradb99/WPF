using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MoviesDB.Infrastructure.Events;
using WPF_MoviesDB.Infrastructure.Models;

namespace Movies.ViewModels
{
    public class MoviesListViewModel: BindableBase
    {

        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        private string _genre;
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                SetProperty(ref _genre, value);
            }
        }

        public MoviesListViewModel(IEventAggregator eventAggregator)
        {
            Message = "Hello from Movies View Model";
            Genre = "Your selected genre is: ";
            eventAggregator.GetEvent<SelectedChangeEvent>().Subscribe(OnSelectionChange);
        }

        private void OnSelectionChange(Genre selectedGenre)
        {
            Genre = selectedGenre.name;
        }
    }
}
