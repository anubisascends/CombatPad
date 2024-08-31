using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CombatPad.Models
{
    public partial class CombatItem : ObservableObject, IDraggable
    {
        [ObservableProperty]
        private CombatItemType _Type;
        [ObservableProperty]
        private int _Counter;
        [ObservableProperty]
        private string? _Label;
        [ObservableProperty]
        private double _Top;
        [ObservableProperty]
        private double _Left;
    }
}
