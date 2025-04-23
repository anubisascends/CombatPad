using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CombatPad.Classes
{
    public class BoolToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is bool bValue)
            {
                return bValue ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            }

            return new GridLength(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
