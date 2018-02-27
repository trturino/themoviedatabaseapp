using System;
using System.Globalization;
using Xamarin.Forms;

namespace TMDBApp.Core.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var retStr = string.Empty;

            if (value != null)
                retStr = ((DateTime) value).ToString("d");

            return retStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}