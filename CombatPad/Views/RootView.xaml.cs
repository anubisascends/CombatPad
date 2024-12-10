using CombatPad.ViewModels;
using CombatPad.Views.Interfaces;
using Microsoft.Extensions.Hosting;

namespace CombatPad.Views
{
    /// <summary>
    /// Interaction logic for RootView.xaml
    /// </summary>
    public partial class RootView : IView<RootViewModel>, IHostedService
    {
        public RootView(RootViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }

        public RootViewModel ViewModel { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Show();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Close();
            return Task.CompletedTask;
        }
    }
}
