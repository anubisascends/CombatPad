using System.Windows;

namespace CombatPad.Components
{
    /// <summary>
    /// Interaction logic for HitPointsComponent.xaml
    /// </summary>
    public partial class HitPointsComponent
    {
        public HitPointsComponent()
        {
            InitializeComponent();
        }

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public int Damage
        {
            get { return (int)GetValue(DamageProperty); }
            set { SetValue(DamageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Damage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DamageProperty =
            DependencyProperty.Register("Damage", typeof(int), typeof(HitPointsComponent), new PropertyMetadata(0));

        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(int), typeof(HitPointsComponent), new PropertyMetadata(0));

        private void PackIconMaterial_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Damage = 0;
        }

        private void PackIconPhosphorIcons_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
