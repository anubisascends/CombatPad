using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace CombatPad.Models
{
    public partial class MarkerItem : ObservableObject, IDraggable
    {
        [ObservableProperty]
        private double _Left;
        [ObservableProperty]
        private double _Top;
        [ObservableProperty]
        private string? _Label;
        [ObservableProperty]
        private Color _Color = Colors.Black;
    }
}
