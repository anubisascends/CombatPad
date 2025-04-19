using System.Windows;

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

        // Using a DependencyProperty as the backing store for Score.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScoreProperty =
            DependencyProperty.Register("Score", typeof(int), typeof(AbilityScoreComponent), new PropertyMetadata(0));

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AbilityScoreComponent), new PropertyMetadata(""));
    }
}
