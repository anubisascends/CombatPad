using CombatPad.Classes;
using CombatPad.Repositories;
using CombatPad.Repositories.Interfaces;
using CombatPad.ViewModels;
using CombatPad.Views;
using MahApps.Metro.Controls.Dialogs;
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
                services.AddHostedService<RootView>();

                services.AddSingleton<RootViewModel>();
                services.AddSingleton(DialogCoordinator.Instance);

                services.AddTransient<IRepository, FileRepository>();
            })
            .Build();

        public static AbilityScoreConverter AbilityScoreConverter => (AbilityScoreConverter)Current.Resources["Application.Converters.Modifier"];

        protected override void OnStartup(StartupEventArgs e) => Host.Start();
    }

}
