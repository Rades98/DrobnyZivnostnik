namespace AxiosControls.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class HasDataBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(value is null);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
