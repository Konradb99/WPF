using Dialogs.ViewModels;
using Dialogs.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Dialogs
{
    public class DialogsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<SettingsDialogView, SettingsDialogViewModel>("SettingsDialog");
        }
    }
}