namespace DrobnyZivnostnik.Controls
{
    using Xamarin.Forms;

    class AxiosImage : Image
    {
        [TypeConverter(typeof(Converters.ImageSourceConverter))]
        public new ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }
    }
}
