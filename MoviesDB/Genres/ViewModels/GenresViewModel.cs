using Genres.Views;
using Movies.ViewModels;
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
        private readonly FavouritesListViewModel _favouritesListViewModel;
        private readonly MoviesListViewModel _moviesListViewModel;

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
                _favouritesListViewModel.Genre = value.name;
                SetProperty(ref _selectedGenre, value);
            }
        }

        public GenresViewModel(
            IGenresService genreService, 
            IRegionManager regionManager, 
            FavouritesListViewModel favouritesListViewModel, 
            MoviesListViewModel moviesListViewModel)
        {
            _genreService = genreService;
            _regionManager = regionManager;
            _favouritesListViewModel = favouritesListViewModel;
            _moviesListViewModel = moviesListViewModel;
            getMovies();
            
        }

        public async void getMovies()
        {
            Genres = new ObservableCollection<Genre>(await _genreService.GetGenres());
        }
    }
}
