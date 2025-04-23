using CombatPad.Models.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace CombatPad.Models
{
    public partial class NonPlayerCharacter : ListItem, IConditionContainer
    {
        public ObservableCollection<Condition> Conditions { get; } = [];

        [ObservableProperty]
        private byte _Strength;
        [ObservableProperty]
        private byte _Dexterity;
        [ObservableProperty]
        private byte _Constitution;
        [ObservableProperty]
        private byte _Intelligence;
        [ObservableProperty]
        private byte _Wisdom;
        [ObservableProperty]
        private byte _Charisma;
        [ObservableProperty]
        private byte _StrengthSave;
        [ObservableProperty]
        private int _Initaitve;
        [ObservableProperty]
        private int _HitPoints;
        [ObservableProperty]
        private int _Damage;
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
    }
}