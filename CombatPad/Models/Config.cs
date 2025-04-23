using CommunityToolkit.Mvvm.ComponentModel;

namespace CombatPad.Models
{
    public partial class Config : ObservableObject
    {
        [ObservableProperty]
        private bool _ShowModifiers = true;
        [ObservableProperty]
        private bool _ShowSaves = true;
    }
}
