using CombatPad.Classes;

namespace CombatPad.Models.Interfaces
{
    public interface ISizeContainer : IAbilityScoreContainer
    {
        CreatureSize Size { get; }
    }
}
