namespace CombatPad.Classes
{
    [Flags]
    public enum Abilities
    {
        Strength = 0x01,
        Dexterity = 0x02,
        Constitution = 0x04,
        Intelligence = 0x08,
        Wisdom = 0x10,
        Charisma = 0x20
    }
}
