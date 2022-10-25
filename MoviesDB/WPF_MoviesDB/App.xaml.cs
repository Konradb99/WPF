using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;

namespace WPF_MoviesDB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }
    }
}
