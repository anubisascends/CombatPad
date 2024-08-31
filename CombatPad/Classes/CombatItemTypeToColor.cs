using CombatPad.Models;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CombatPad.Classes
{
    public class CombatItemTypeToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var converter = new BrushConverter();

            return value switch
            {
                CombatItemType.Hazard => converter.ConvertFrom("#FF937F7F"),
                CombatItemType.NonPlayerCharacter => converter.ConvertFrom("#FF84201F"),
                CombatItemType.PlayerCharacter => converter.ConvertFromString("#FF3C5D8A"),
                CombatItemType.Condition => converter.ConvertFrom("#FF882324"),
                _ => Brushes.Black
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
