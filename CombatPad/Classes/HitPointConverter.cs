using System.Globalization;
using System.Windows.Data;

namespace CombatPad.Classes
{
    public class HitPointConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var total = System.Convert.ToInt32(values[0]);
            var damage = System.Convert.ToInt32(values[1]);

            return total - damage;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
