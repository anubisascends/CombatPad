using CombatPad.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CombatPad.Classes
{
    public class HitDiceStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is HitPoints hp)
            {
                if(hp.Parent is NonPlayerCharacter)
                {
                    return $"{hp.HitDice}+{hp.BonusHitPoints} ({hp.MonsterHitPoints} hp)";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
