using System;
using Windows.UI.Xaml.Data;

namespace ComboApp.Converters
{
    public class OrderTypeConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch ((string)value)
            {
                case "M":
                    return "Manual";
                case "A":
                    return "Automatic";
                case "S":
                    return "Semi-automatic";
                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
