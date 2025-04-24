using CombatPad.Models;
using System.Windows;

namespace CombatPad.Components
{
    /// <summary>
    /// Interaction logic for DraggableItemComponent.xaml
    /// </summary>
    public partial class DraggableItemComponent
    {
        public DraggableItemComponent()
        {
            InitializeComponent();
        }

        public ListItem Item
        {
            get { return (ListItem)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Item.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemProperty =
            DependencyProperty.Register("Item", typeof(ListItem), typeof(DraggableItemComponent), new PropertyMetadata(null));
    }
}
