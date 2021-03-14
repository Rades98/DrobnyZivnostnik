namespace DrobnyZivnostnik.Converters
{
    using System;
    using Xamarin.Forms;

    [Xamarin.Forms.Xaml.TypeConversion(typeof(ImageSource))]
    public sealed class ImageSourceConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (value == null)
            {
                throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(ImageSource)}");
            }

            return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme != "file" ? 
                ImageSource.FromUri(uri) : ImageSource.FromResource($"DrobnyZivnostnik.Resources.Drawable.{value as string}");
        }
    }
}
