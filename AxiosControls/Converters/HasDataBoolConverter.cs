namespace AxiosControls.Converters
{
    using System;
    using System.Globalization;
    using Axios.Extensions;
    using Xamarin.Forms;

    public class HasDataBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.IsNotNull();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
