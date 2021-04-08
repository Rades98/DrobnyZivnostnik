namespace DrobnyZivnostnik.Controls
{
    using System.ComponentModel;
    using Services.Interfaces;
    using Xamarin.Forms;

    class AxiosLocalizedPicker : Picker
    {
        private static readonly ILocalizationService LocalizationService = DependencyService.Get<ILocalizationService>();

        /// <summary>
        /// The Title text key property
        /// </summary>
        public static readonly BindableProperty TitleTextKeyProperty =
            BindableProperty.Create(
                nameof(TitleTextKey),
                typeof(string),
                typeof(AxiosLocalizedPicker),
                default(string),
                propertyChanged: OnTitleTextKeyPropertyChanged);

        [Description("Key of resource")]
        public string TitleTextKey
        {
            get => (string)GetValue(TitleTextKeyProperty);
            set => SetValue(TitleTextKeyProperty, value);
        }

        /// <summary>
        /// Called when [Title text key property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        static void OnTitleTextKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Picker)bindable).Title = LocalizationService.GetResourceByKey((string)newValue);
        }
    }
}
