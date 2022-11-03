using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MoviesDB.Core.Constants;
using WPF_MoviesDB.Infrastructure.Events;
using WPF_MoviesDB.Infrastructure.Models;
using WPF_MoviesDB.Infrastructure.Services;

namespace Movies.ViewModels
{
    public class MoviesListViewModel : BindableBase
    {
        private readonly IMoviesService _moviesService;

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

        public MoviesListViewModel(IEventAggregator eventAggregator, IMoviesService moviesService)
        {
            eventAggregator.GetEvent<SelectedChangeEvent>().Subscribe(OnSelectionChange);
            _moviesService = moviesService;
        }

        private async void OnSelectionChange(Genre selectedGenre)
        {
            Movies = await _moviesService.GetMoviesPageByGenre(selectedGenre.id, DefaultValues.defaultPageNumber);
        }
    }
}
