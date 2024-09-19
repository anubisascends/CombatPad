using CombatPad.Classes;
using CombatPad.Classes.Interfaces;
using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace CombatPad.Models
{
    public partial class Initiative : ObservableObject, IParented<IAbilityScoreContainer>
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private IAbilityScoreContainer _Parent;

        [ObservableProperty]
        private int _Temp;
        [ObservableProperty]
        private int _Penalty;
        [ObservableProperty]
        private int _Result;

        public Initiative(IAbilityScoreContainer parent)
        {
            _Parent = parent;
            Parent.Dexterity.PropertyChanged += onDexChanged;
        }

        public int Total => RpgMath.Modifier(Parent?.Dexterity.Total ?? 0) +
            Temp -
            Penalty;

        public void Roll() => Result = Total + Random.Shared.Next(0, 20) + 1;

        private void onDexChanged(object? sender, PropertyChangedEventArgs e) => OnPropertyChanged(nameof(Total));
    }
}
