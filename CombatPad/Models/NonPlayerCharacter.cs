using CombatPad.Classes;
using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CombatPad.Models
{
    public partial class NonPlayerCharacter : ListItem, IAbilityScoreContainer, ISkillContainer, IConditionContainer, ISizeContainer
    {
        public NonPlayerCharacter()
        {
            Strength = new(this);
            Dexterity = new(this);
            Constitution = new(this);
            Intelligence = new(this);
            Wisdom = new(this);
            Charisma = new(this);
            Skills = new(this);
            Initaitve = new(this);
            HitPoints = new(this);
        }

        public AbilityScore Strength {get;}
        public AbilityScore Dexterity { get; }
        public AbilityScore Constitution { get; }
        public AbilityScore Intelligence { get; }
        public AbilityScore Wisdom { get; }
        public AbilityScore Charisma { get; }
        public ParentedObservableCollection<ISkillContainer, Skill> Skills { get; }
        public ObservableCollection<Condition> Conditions { get; } = [];
        public Initiative Initaitve { get; }
        public HitPoints HitPoints { get; }

        [ObservableProperty]
        private string? _Speed;
        [ObservableProperty]
        private byte _BaseAttack;
        [ObservableProperty]
        private CreatureSize _Size;
        [ObservableProperty]
        private byte _ChallengeRating;
        [ObservableProperty]
        private CreatureType _Type;
        [ObservableProperty]
        private CreatureSubType _SubType;
        [ObservableProperty]
        private string? _Description;

        public AbilityScore? GetAbility(Abilities ability) => GetType().GetProperty(ability.ToString())?.GetValue(this) as AbilityScore;
    }
}