using CombatPad.Models;
using System.Globalization;
using System.Windows.Data;

namespace CombatPad.Classes
{
    public class CombatItemShortNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                PlayerCharacter => "PC",
                NonPlayerCharacter => "NPC",
                Hazard => "HAZ",
                Condition => "CON",
                _ => "PC"
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
