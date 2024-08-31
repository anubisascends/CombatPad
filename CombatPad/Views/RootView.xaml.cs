using CombatPad.ViewModels;

namespace CombatPad.Views
{
    /// <summary>
    /// Interaction logic for RootView.xaml
    /// </summary>
    public partial class RootView : IView<RootViewModel>
    {
        public RootView(RootViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }

        public RootViewModel ViewModel { get; }
    }
}
