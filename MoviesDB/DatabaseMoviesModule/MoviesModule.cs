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
            regionManager.RegisterViewWithRegion("TabRegion", typeof(MoviesContentView));
            regionManager.RegisterViewWithRegion("TabRegion", typeof(FavouritesContentView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}