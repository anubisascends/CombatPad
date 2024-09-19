using CombatPad.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatPad.Models.Interfaces
{
    public interface IAbilityScoreContainer
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
