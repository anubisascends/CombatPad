using CombatPad.Classes;
using CombatPad.Classes.Interfaces;
using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;

namespace CombatPad.Models
{
    public partial class Skill : ObservableObject, IParented<ISkillContainer>, IDisposable
    {
        private bool _disposed;

        public ISkillContainer Parent { get; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private int _Ranks;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private int _Temp;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private int _Penalty;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private Abilities _Ability;

        public Skill(Abilities ability, ISkillContainer parent)
        {
            _Ability = ability;
            Parent = parent;

            Parent.GetAbility(Ability)!.PropertyChanged += onAbilityChanged;
        }

        public int Total => Ranks +
            RpgMath.Modifier((Parent?.GetAbility(Ability)?.Total ?? 0)) +
            Temp +
            Penalty;

        private void onAbilityChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AbilityScore.Total))
            {
                OnPropertyChanged(nameof(Total));
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Parent.GetAbility(Ability)!.PropertyChanged -= onAbilityChanged;
                _disposed = true;
            }
        }

        ~Skill() => Dispose();
    }
}