using System.Globalization;
using System.Windows.Data;

namespace CombatPad.Classes
{
    public class SubTypeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = $"({value})";

            if(result.Length < 4)
            {
                return string.Empty;
            }

            return result.SplitCamelCase();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
