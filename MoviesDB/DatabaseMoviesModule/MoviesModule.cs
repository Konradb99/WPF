using Movies.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Movies
{
    public class MoviesModule : IModule
    {
        IRegionManager _regionManager;
        public MoviesModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MoviesListView));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(FavouritesListView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}