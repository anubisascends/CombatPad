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

        private void Score_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var roll = Random.Shared.Next(1, 21) + Score;

            DisplayRoll(roll, $"{Title} Score", Score);
        }

        private void Modifier_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var modifier = (int)App.AbilityScoreConverter.Convert(Score, typeof(int), null!, null!);
            var roll = Random.Shared.Next(1, 21) + modifier ;

            DisplayRoll(roll, $"{Title} Modifier", modifier);
        }

        private void Save_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var roll = Random.Shared.Next(1, 21) + Save;

            DisplayRoll(roll, $"{Title} Save", Save);
        }

        private void DisplayRoll(int roll, string title) => DisplayRoll(roll, title, []);

        private void DisplayRoll(int roll, int modifier, string title) => DisplayRoll(roll, title, [modifier]);

        private void DisplayRoll(int roll, string title, params IEnumerable<int> modifiers)
        {
            var modString = string.Join(" + ", modifiers);
            var rollString = "Roll";

            if(modString.Length > 0)
            {
                rollString += $" + {modString}";
            }

            MessageBox.Show($"{rollString} = {roll}", title);
        }
    }
}
