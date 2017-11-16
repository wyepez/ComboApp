using System;
using Windows.UI.Xaml.Data;

namespace ComboApp.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime date = (DateTime)value;
            DateTimeOffset result = date;
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset date = (DateTimeOffset)value;
            return date.DateTime;
        }
    }
}
