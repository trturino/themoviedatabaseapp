using System;
using System.Globalization;
using Xamarin.Forms;

namespace TMDBApp.Core.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var rtnStr = string.Empty;

            if (value != null)
                rtnStr = $@"https://image.tmdb.org/t/p/w780/{value}";

            return rtnStr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
