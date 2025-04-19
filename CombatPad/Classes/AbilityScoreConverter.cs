using System.Globalization;
using System.Windows.Data;

namespace CombatPad.Classes
{
    public class AbilityScoreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bValue = System.Convert.ToByte(value);

            return RpgMath.Modifier(bValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
