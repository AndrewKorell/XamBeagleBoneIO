using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BleBeagleBone.Converters
{
    public class GuidToStringConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Guid)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
