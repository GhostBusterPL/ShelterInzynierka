using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ShelterInzynierka.ValueConverters
{
    class HaveCastrationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case true:
                    return "Tak";
                case false:
                    return "Nie";
                default:
                    return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Tak":
                    return true;
                case "Nie":
                    return false;
                default:
                    return Binding.DoNothing;
            }
        }
    }
}
