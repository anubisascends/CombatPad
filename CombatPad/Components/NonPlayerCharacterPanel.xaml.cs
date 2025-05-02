using CombatPad.ViewModels.Interfaces;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace CombatPad.Components
{
    /// <summary>
    /// Interaction logic for NonPlayerCharacterPanel.xaml
    /// </summary>
    public partial class NonPlayerCharacterPanel
    {
        public NonPlayerCharacterPanel()
        {
            InitializeComponent();
        }

        public bool ShowAbilityModifiers
        {
            get { return (bool)GetValue(ShowAbilityModifiersProperty); }
            set { SetValue(ShowAbilityModifiersProperty, value); }
        }

        public bool ShowAbilitySaves
        {
            get { return (bool)GetValue(ShowAbilitySavesProperty); }
            set { SetValue(ShowAbilitySavesProperty, value); }
        }

        public IViewModel DialogCoordinatorViewModel
        {
            get { return (IViewModel)GetValue(DialogCoordinatorViewModelProperty); }
            set { SetValue(DialogCoordinatorViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogCoordinatorViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogCoordinatorViewModelProperty =
            DependencyProperty.Register("DialogCoordinatorViewModel", typeof(IViewModel), typeof(NonPlayerCharacterPanel), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for ShowAbilitySaves.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowAbilitySavesProperty =
            DependencyProperty.Register("ShowAbilitySaves", typeof(bool), typeof(NonPlayerCharacterPanel), new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for ShowAbilityModifiers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowAbilityModifiersProperty =
            DependencyProperty.Register("ShowAbilityModifiers", typeof(bool), typeof(NonPlayerCharacterPanel), new PropertyMetadata(true));
    }
}
