namespace CombatPad.Classes
{
    [Flags]
    public enum CreatureType
    {
        Aberration = 0x01,
        Animal = 0x02,
        Construct = 0x04,
        Dragon = 0x08,
        Elemental = 0x10,
        Fey = 0x20,
        Giant = 0x40,
        Humanoid = 0x80,
        MagicalBeast = 0x100,
        MonstrousHumanoid = 0x200,
        Ooze = 0x400,
        Outsider = 0x800,
        Plant = 0x1000,
        Undead = 0x2000,
        Vermin = 0x4000
    }
}
