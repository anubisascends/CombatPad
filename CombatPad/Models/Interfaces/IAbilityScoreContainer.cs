using CombatPad.Classes;
using System.ComponentModel;

namespace CombatPad.Models.Interfaces
{
    public interface IAbilityScoreContainer : INotifyPropertyChanged
    {
        AbilityScore Strength { get; }
        AbilityScore Dexterity { get; }
        AbilityScore Constitution { get; }
        AbilityScore Intelligence{ get; }
        AbilityScore Wisdom { get; }
        AbilityScore Charisma { get; }

        AbilityScore? GetAbility(Abilities ability);
    }
}
