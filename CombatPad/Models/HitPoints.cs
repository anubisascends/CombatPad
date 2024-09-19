using CombatPad.Classes.Interfaces;
using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CombatPad.Models
{
    public partial class HitPoints : ObservableObject, IParented<IAbilityScoreContainer>
    {
        public IAbilityScoreContainer Parent { get; init; }
        public HitDice HitDice { get; init; } = [];

        public HitPoints(IAbilityScoreContainer parent)
        {
            Parent = parent;
            Parent.Constitution.PropertyChanged += onConChanged;
            HitDice.CollectionChanged += onHitDiceChanged;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(CharacterHitPoints))]
        private bool _UseMax;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(MonsterHitPoints), nameof(CharacterHitPoints))]
        private int _BonusHitPoints;

        [JsonIgnore]
        public int MonsterHitPoints => GetMonsterTotal();
        [JsonIgnore]
        public int CharacterHitPoints => GetCharacterTotal();

        private int GetMonsterTotal() => HitDice.Average + 
            BonusHitPoints;
        private int GetCharacterTotal() => (UseMax ? HitDice.Max : HitDice.Rolled ) +
            BonusHitPoints;

        private void onConChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(MonsterHitPoints));
        }
        private void onHitDiceChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(MonsterHitPoints));
            OnPropertyChanged(nameof(CharacterHitPoints));
        }
    }
}
