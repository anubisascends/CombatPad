using CombatPad.Models;
using System.Globalization;
using System.Windows.Data;

namespace CombatPad.Classes
{
    public class CombatItemShortNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is CombatItem item)
            {
                return item.Type switch
                {
                    CombatItemType.NonPlayerCharacter => "NPC",
                    CombatItemType.Hazard => "HAZ",
                    CombatItemType.Condition => "CON",
                    _ => "PC"
                };
            }

            return value?.ToString() ?? string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
