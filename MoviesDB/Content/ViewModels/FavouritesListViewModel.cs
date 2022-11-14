using Prism.Events;
using Prism.Mvvm;
using WPF_MoviesDB.Infrastructure.Events;
using WPF_MoviesDB.Infrastructure.Models;

namespace Content.ViewModels
{
    public class FavouritesListViewModel : BindableBase
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

        public FavouritesListViewModel(IEventAggregator eventAggregator)
        {
            Message = "Hello from Favourites View Model";
            Genre = "Your selected genre is: ";
            eventAggregator.GetEvent<SelectedChangeEvent>().Subscribe(OnSelectionChange);
        }

        private void OnSelectionChange(Genre selectedGenre)
        {
            Genre = selectedGenre.name;
        }
    }
}