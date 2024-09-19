using CommunityToolkit.Mvvm.ComponentModel;

namespace CombatPad.Models
{
    public partial class PlayerCharacter : NonPlayerCharacter
    {
        [ObservableProperty]
        private string? _PlayerName;
    }
}