using System;
using Windows.UI.Xaml.Data;

namespace ComboApp.Converters
{
    public class TransactionTypeConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            switch ((string)value)
            {
                case "I":
                    return "Incoming";
                case "O":
                    return "Outgoing";
                case "T":
                    return "Transfer";
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
