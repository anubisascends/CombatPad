using CombatPad.Repositories;
using CombatPad.Repositories.Interfaces;
using CombatPad.ViewModels;
using CombatPad.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CombatPad
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost Host { get; } = new HostBuilder()
            .ConfigureServices(services => {
                services.AddSingleton<RootView>();
                services.AddSingleton<RootViewModel>();

                services.AddTransient<IRepository, FileRepository>();
            })
            .Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            var view = Host.Services.GetRequiredService<RootView>();

            view.Show();
        }
    }

}
