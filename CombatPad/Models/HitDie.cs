using System.Text.Json.Serialization;

namespace CombatPad.Models
{
    public record struct HitDie(int Sides)
    {
        [JsonIgnore]
        public readonly int Average => Sides / 2;
        public int Rolled { get; set; }

        public int Roll() => Rolled = Random.Shared.Next(0, Sides) + 1;

        public static implicit operator HitDie(int Sides) => new HitDie(Sides);
        public static implicit operator int(HitDie h) => h.Sides;
    }
}
