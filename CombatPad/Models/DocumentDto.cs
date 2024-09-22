namespace CombatPad.Models
{
    public record struct DocumentDto(IEnumerable<PlayerCharacter> PCs, IEnumerable<NonPlayerCharacter> NPCs, 
        IEnumerable<Hazard> Hazards, IEnumerable<Condition> Conditions, IEnumerable<MarkerItem> MarkerItems);
}
