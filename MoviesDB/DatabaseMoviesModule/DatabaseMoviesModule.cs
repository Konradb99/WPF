using DatabaseMovies.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DatabaseMovies
{
    public class DatabaseMoviesModule : IModule
    {
        IRegionManager _regionManager;
        public DatabaseMoviesModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(MoviesListView));
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(FavListView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}