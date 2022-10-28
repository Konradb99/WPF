using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Net.Http;
using WPF_MoviesDB.Core.Constants;
using WPF_MoviesDB.Infrastructure.Models;
using WPF_MoviesDB.Infrastructure.Services;

namespace Genres.ViewModels
{
    public class GenresViewModel : BindableBase
    {
        private readonly IGenresService _genreService;
        private readonly IRegionManager _regionManager;
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private ObservableCollection<Genre> _genres = new ObservableCollection<Genre>();

        public ObservableCollection<Genre> Genres
        {
            get
            {
                return _genres;
            }
            set
            {
                SetProperty(ref _genres, value);
            }
        }

        private Genre _selectedGenre;

        public Genre SelectedGenre
        {
            get { return _selectedGenre; }
            set
            {
                _regionManager.RequestNavigate("TabRegion", "FavouriteMoviesView");
                SetProperty(ref _selectedGenre, value);
            }
        }

        public GenresViewModel(IGenresService genreService, IRegionManager regionManager)
        {
            _genreService = genreService;
            _regionManager = regionManager;
            Message = ApiConstants.apiKey;
            getMovies();
            
        }

        public async void getMovies()
        {
            Genres = new ObservableCollection<Genre>(await _genreService.GetGenres());
        }
    }
}
