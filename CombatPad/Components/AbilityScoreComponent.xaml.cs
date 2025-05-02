using CombatPad.ViewModels.Interfaces;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;
using System.Windows.Input;

namespace CombatPad.Components
{
    /// <summary>
    /// Interaction logic for AbilityScoreComponent.xaml
    /// </summary>
    public partial class AbilityScoreComponent
    {
        public AbilityScoreComponent()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        public int Save
        {
            get { return (int)GetValue(SaveProperty); }
            set { SetValue(SaveProperty, value); }
        }

        public bool ShowModifier
        {
            get { return (bool)GetValue(ShowModifierProperty); }
            set { SetValue(ShowModifierProperty, value); }
        }

        public bool ShowSave
        {
            get { return (bool)GetValue(ShowSaveProperty); }
            set { SetValue(ShowSaveProperty, value); }
        }

        public IViewModel DialogCoordinatorViewModel
        {
            get { return (IViewModel)GetValue(DialogCoordinatorViewModelProperty); }
            set { SetValue(DialogCoordinatorViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DialogCoordinatorViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogCoordinatorViewModelProperty =
            DependencyProperty.Register("DialogCoordinatorViewModel", typeof(IViewModel), typeof(AbilityScoreComponent), new PropertyMetadata(null));

        // Using a DependencyProperty as the backing store for Save.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveProperty =
            DependencyProperty.Register("Save", typeof(int), typeof(AbilityScoreComponent), new PropertyMetadata(0));

        // Using a DependencyProperty as the backing store for ShowSave.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowSaveProperty =
            DependencyProperty.Register("ShowSave", typeof(bool), typeof(AbilityScoreComponent), new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for ShowModifier.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowModifierProperty =
            DependencyProperty.Register("ShowModifier", typeof(bool), typeof(AbilityScoreComponent), new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for Score.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register("Score", typeof(int), typeof(AbilityScoreComponent), new PropertyMetadata(0));

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AbilityScoreComponent), new PropertyMetadata(""));

        private async void Score_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var roll = Random.Shared.Next(1, 21);

            await DisplayRoll(roll, roll + Score, $"{Title} Score", Score);
        }

        private async void Modifier_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var modifier = (int)App.AbilityScoreConverter.Convert(Score, typeof(int), null!, null!);
            var roll = Random.Shared.Next(1, 21) ;

            await DisplayRoll(roll, roll + modifier, $"{Title} Modifier", modifier);
        }

        private async void Save_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var roll = Random.Shared.Next(1, 21) + Save;

            await DisplayRoll(roll, roll + Save, $"{Title} Save", Save);
        }

        private async Task DisplayRoll(int roll, int result, string title, params IEnumerable<int> modifiers)
        {
            var modString = string.Join(" + ", modifiers);
            var rollString = $"Roll {result} ({roll}";

            if(modString.Length > 0)
            {
                rollString += $" + {modString}";
            }

            rollString += ")";

            _ = await DialogCoordinator
                .Instance
                .ShowMessageAsync(DialogCoordinatorViewModel, title, rollString);
        }
    }
}
