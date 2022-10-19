using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_Pokedex.Shared;
using WPF_Pokedex.Views.MainPanel;
using WPF_Pokedex.Views.PokemonDetails;
using WPF_Pokedex.Views.PokemonList;
using WPF_Pokedex.Views.TypesList;
using WPF_Pokedex_data_access.Repository;

namespace WPF_Pokedex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddScoped<TypeRepository>();
            services.AddScoped<PokemonRepository>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<TypesListViewModel>();
            services.AddScoped<PokemonListViewModel>();
            services.AddScoped<MainPanelViewModel>();
            services.AddScoped<PokemonDetailsViewModel>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
