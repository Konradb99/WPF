﻿using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using WPF_MoviesDB.Infrastructure.Events;
using WPF_MoviesDB.Infrastructure.Models;

namespace Content.ViewModels
{
    public class MovieDetailsViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand GoBackCommand { get; private set; }

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

        private Movie _movie;
        public Movie Movie
        {
            get
            {
                return _movie;
            }
            set
            {
                SetProperty(ref _movie, value);
            }
        }

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                SetProperty(ref _title, value);
            }
        }

        public MovieDetailsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            Message = "Hello from MovieDetailsView";
            Title = "Movie title";
            GoBackCommand = new DelegateCommand(Click, CanClick);
            _regionManager = regionManager;
        }

        private void Click()
        {
            _regionManager.RequestNavigate("MoviesContentRegion", "MoviesListView");
        }

        private bool CanClick()
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("movie"))
            {
                Movie = navigationContext.Parameters.GetValue<Movie>("movie");
                Title = Movie.title;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
