using CombatPad.Models;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

using Condition = CombatPad.Models.Condition;

namespace CombatPad.Classes
{
    public class CombatItemTypeToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value switch
            {
                Condition => (Brush)Application.Current.Resources["Application.Brushes.Solid.Condition"],
                Hazard => (Brush)Application.Current.Resources["Application.Brushes.Solid.Hazard"],
                PlayerCharacter => (Brush)Application.Current.Resources["Application.Brushes.Solid.PlayerCharacter"],
                NonPlayerCharacter => (Brush)Application.Current.Resources["Application.Brushes.Solid.NonPlayerCharacter"],
                _ => Brushes.Black
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
