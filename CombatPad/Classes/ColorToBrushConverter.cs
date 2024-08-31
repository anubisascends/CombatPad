using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CombatPad.Classes
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Color color)
            {
                return new SolidColorBrush(color);
            }

            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
