using Genres.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Genres
{
    public class GenresModule : IModule
    {
        private IRegionManager _regionManager;

        public GenresModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("GenresRegion", typeof(GenresView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}