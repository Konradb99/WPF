using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using WPF_MoviesDB.Infrastructure.DatabaseEntities;
using WPF_MoviesDB.Infrastructure.Models;
using WPF_MoviesDB.Infrastructure.Repositories;

namespace Dialogs.ViewModels
{
    public class SettingsDialogViewModel : BindableBase, IDialogAware
    {
        public DelegateCommand<string> CloseDialogCommand { get; private set; }
        private readonly IMovieRepository _movieRepository;

        private string _title = "Notification";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Movie _movie;

        public Movie Movie
        {
            get { return _movie; }
            set
            {
                SetProperty(ref _movie, value);
            }
        }

        public SettingsDialogViewModel(IMovieRepository movieRepository)
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            _movieRepository = movieRepository;
        }

        public event Action<IDialogResult> RequestClose;

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.OK;

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            MovieEntity movieToAdd = new()
            {
                title = parameters.GetValue<string>("title"),
                overview = parameters.GetValue<string>("overview"),
                backdrop_path = parameters.GetValue<string>("backdrop_path"),
                poster_path = parameters.GetValue<string>("poster_path"),
                release_date = parameters.GetValue<string>("release_date"),
                vote = Double.Parse(parameters.GetValue<string>("vote"))
            };
            _movieRepository.AddMovieToFavourites(movieToAdd);
        }
    }
}