namespace CombatPad.Classes
{
    [Flags]
    public enum CreatureSubType
    {
        Air = 0x01,
        Angel = 0x02,
        Aquatic = 0x04,
        Archon = 0x08,
        Augmented = 0x10,
        Chaotic = 0x20,
        Cold = 0x40,
        Earth = 0x80,
        Evil = 0x100,
        Extraplanar = 0x200,
        Fire = 0x200,
        Goblinoid = 0x400,
        Good = 0x800,
        Incorporeal = 0x1000,
        Lawful = 0x2000,
        Native = 0x4000,
        Reptilian = 0x8000,
        Shapechanger = 0x10000,
        Swarm = 0x20000,
        Water = 0x40000
    }
}
