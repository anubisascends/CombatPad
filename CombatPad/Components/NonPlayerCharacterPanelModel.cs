using CombatPad.Models;
using CombatPad.ViewModels.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CombatPad.Components
{
    public partial class NonPlayerCharacterPanelModel : ObservableObject, IViewModel
    {
        [ObservableProperty]
        private NonPlayerCharacter? _Character;
    }
}
