using Renci.SshNet.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ShelterInzynierka.ValueConverters
{
    class OnlyYearMonthDay : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime defaultDate = (DateTime)value;
            if (defaultDate == DateTime.MinValue)
            {
                return null;
            }
            else
            {
                DateTime returnDate = (DateTime)value;
                return returnDate.ToString("yyyy-MM-dd");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
