using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using WPF_MoviesDB.Core.Constants;
using WPF_MoviesDB.Infrastructure.Events;
using WPF_MoviesDB.Infrastructure.Models;
using WPF_MoviesDB.Infrastructure.Services;

namespace Content.ViewModels
{
    public class MoviesListViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IMoviesService _moviesService;
        private readonly IRegionManager _regionManager;

        private IEnumerable<Movie> _movies;

        public IEnumerable<Movie> Movies
        {
            get
            {
                return _movies;
            }
            set
            {
                SetProperty(ref _movies, value);
            }
        }

        private Movie _selectedMovie;

        public Movie SelectedMovie
        {
            get
            {
                return _selectedMovie;
            }
            set
            {
                var navigateParams = new NavigationParameters();
                navigateParams.Add("movie", value);
                _regionManager.RequestNavigate("MoviesContentRegion", "MovieDetailsView", navigateParams);
                SetProperty(ref _selectedMovie, value);
            }
        }

        public MoviesListViewModel(IEventAggregator eventAggregator, IMoviesService moviesService, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<SelectedChangeEvent>().Subscribe(OnSelectionChange);
            _eventAggregator.GetEvent<ResetSelectedMovieEvent>().Subscribe(ResetSelectedMovie);
            _moviesService = moviesService;
            _regionManager = regionManager;
            GetDefaultMovies();
        }

        private void ResetSelectedMovie()
        {
            SelectedMovie = new Movie();
        }

        private async void OnSelectionChange(Genre selectedGenre)
        {
            Movies = await _moviesService.GetMoviesPageByGenre(selectedGenre.id, DefaultValues.defaultPageNumber);
        }

        private async void GetDefaultMovies()
        {
            Movies = await _moviesService.GetMoviesPage();
        }
    }
}