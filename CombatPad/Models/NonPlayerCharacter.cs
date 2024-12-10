using CombatPad.Classes;
using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CombatPad.Models
{
    public partial class NonPlayerCharacter : ListItem, IAbilityScoreContainer, ISkillContainer, IConditionContainer
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
        private string _Speed = "30 ft.";
        [ObservableProperty]
        private string _BaseAttack = "0";
        [ObservableProperty]
        private string _Size = "Medium";
        [ObservableProperty]
        private string? _ChallengeRating;
        [ObservableProperty]
        private string _Type = string.Empty;
        [ObservableProperty]
        private string _SubType = string.Empty;
        [ObservableProperty]
        private string? _Description;

        public AbilityScore? GetAbility(Abilities ability) => GetType().GetProperty(ability.ToString())?.GetValue(this) as AbilityScore;
    }
}