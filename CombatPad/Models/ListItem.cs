using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CombatPad.Models
{
    public abstract partial class ListItem : ObservableObject, IDraggable
    {
        [ObservableProperty]
        private double _Top;
        [ObservableProperty]
        private double _Left;
        [ObservableProperty]
        private string _Label;
    }
}