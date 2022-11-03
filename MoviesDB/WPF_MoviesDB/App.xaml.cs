using Movies;
using Genres;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Windows;
using WPF_MoviesDB.Infrastructure.Services;
using Movies.ViewModels;

namespace WPF_MoviesDB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IGenresService, GenresService>();
            containerRegistry.Register<IMoviesService, MoviesService>();
            containerRegistry.Register<FavouritesListViewModel>();
            containerRegistry.Register<MoviesListViewModel>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MoviesModule>();
            moduleCatalog.AddModule<GenresModule>();
        }
    }
}
