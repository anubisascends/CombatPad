using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CombatPad.Models
{
    public partial class AbilityScore(IAbilityScoreContainer parent) : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private int _BaseScore;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private int _Temp;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private int _Penalty;

        public IAbilityScoreContainer Parent { get; init; } = parent;

        public int Total => BaseScore +
            Temp - 
            Penalty;
    }
}