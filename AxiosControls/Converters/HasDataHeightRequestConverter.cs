namespace AxiosControls.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class HasDataHeightRequestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringVal)
            {
                return string.IsNullOrEmpty(stringVal) ? 0 : -1;
            }

            return value is null ? 0 : -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
