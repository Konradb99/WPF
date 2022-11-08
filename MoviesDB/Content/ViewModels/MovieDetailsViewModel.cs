using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using WPF_MoviesDB.Infrastructure.Events;
using WPF_MoviesDB.Infrastructure.Models;

namespace Content.ViewModels
{
    public class MovieDetailsViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;

        public DelegateCommand GoBackCommand { get; private set; }
        public DelegateCommand ShowSettingsCommand { get; private set; }

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

        public MovieDetailsViewModel(
            IEventAggregator eventAggregator, 
            IRegionManager regionManager,
            IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            Message = "Hello from MovieDetailsView";
            Title = "Movie title";

            GoBackCommand = new DelegateCommand(Click, CanClick);
            ShowSettingsCommand = new DelegateCommand(OpenDialog, CanClick);
        }

        private void OpenDialog()
        {
            var message = $"Test message from {Title}";
            _dialogService.ShowDialog("SettingsDialog", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.None)
                    Title = "Result is None";
                else if (r.Result == ButtonResult.OK)
                    Title = "Result is OK";
                else if (r.Result == ButtonResult.Cancel)
                    Title = "Result is Cancel";
                else
                    Title = "I Don't know what you did!?";
            });
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
