using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace CombatPad.Models
{
    public partial class MarkerItem : ListItem, IDraggable
    {
        [ObservableProperty]
        private Color _Color = Colors.Black;
    }
}
