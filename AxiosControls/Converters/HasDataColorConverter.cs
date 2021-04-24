namespace AxiosControls.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class HasDataColorConverter : IValueConverter
    {
        private readonly Color? _color;

        public HasDataColorConverter(Color parameterColor)
        {
            _color = parameterColor;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrEmpty(value as string) ? Color.Transparent : (_color ?? Color.LightCoral);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}