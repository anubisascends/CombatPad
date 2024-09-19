using CombatPad.Classes;
using CombatPad.Classes.Interfaces;
using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CombatPad.Models
{
    public partial class Attack : ObservableObject, IParented<ISizeContainer>
    {
        public ISizeContainer Parent { get; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Attacks))]
        private int _BaseAttack;

        public Attack(ISizeContainer parent)
        {
            Parent = parent;
            Parent.Strength.PropertyChanged += onStrengthChanged;
        }

        [JsonIgnore]
        public IEnumerable<int> Attacks => GetAttacks(Modifier(Parent.Size));

        [JsonIgnore]
        public IEnumerable<int> Grapple => GetAttacks(
            Modifier(Parent.Size) +
            Parent.Strength.Total);


        private IEnumerable<int> GetAttacks(int bonus = 0)
        {
            var result = Math.DivRem(BaseAttack, 5);
            var attacks = Enumerable.Repeat(6 + bonus, result.Quotient).ToList<int>();

            attacks.Add(result.Remainder + bonus);

            return attacks;
        }
        private int Modifier(CreatureSize size) => size switch 
        {
            CreatureSize.Fine => -16,
            CreatureSize.Diminutime => -12,
            CreatureSize.Tiny => -8,
            CreatureSize.Small => -4,
            CreatureSize.Large => 4,
            CreatureSize.Huge => 8,
            CreatureSize.Gargantuan => 12,
            CreatureSize.Colossal => 16,
            _ => 0
        };
        private void onStrengthChanged(object? sender, PropertyChangedEventArgs e) => OnPropertyChanged(nameof(Attacks));

        public override string ToString() => string.Join('/', GetAttacks().Select(x => x.ToString()));
    }
}
