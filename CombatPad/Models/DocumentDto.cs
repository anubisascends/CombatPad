using System.Windows.Ink;

namespace CombatPad.Models
{
    public record struct DocumentDto(IEnumerable<CombatItem> CombatItems, IEnumerable<MarkerItem> MarkerItems, StrokeCollection Strokes);
}
