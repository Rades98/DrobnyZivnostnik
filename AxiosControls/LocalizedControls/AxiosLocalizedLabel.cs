namespace AxiosControls.LocalizedControls
{
    using Axios.Extensions;
    using AxiosServices.Services.Interfaces;
    using System;
    using System.ComponentModel;
    using Xamarin.Forms;

    /// <summary>
    /// Custom label with localization
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Label" />
    public class AxiosLocalizedLabel : Label
    {
        private static readonly ILocalizationService LocalizationService = DependencyService.Get<ILocalizationService>();

        public AxiosLocalizedLabel()
        {
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            var type = (Type)GetValue(LabelSourceTypeProperty);
            var propName = (string)GetValue(LabelSourceProperty);
            if (type.IsNotNull() && propName.IsNotNull())
            {
                Text = LocalizationService.GetResourceByKey(type.GetProperty(propName));
            }
        }

        /// <summary>
        /// The label text key property
        /// </summary>
        public static readonly BindableProperty LabelTextKeyProperty =
            BindableProperty.Create(
                nameof(LabelTextKey),
                typeof(string),
                typeof(AxiosLocalizedLabel),
                default(string),
                propertyChanged: OnLabelTextKeyPropertyChanged);

        /// <summary>
        /// The label text key property
        /// </summary>
        public static readonly BindableProperty LabelSourceProperty =
            BindableProperty.Create(
                nameof(LabelTextKey),
                typeof(string),
                typeof(AxiosLocalizedLabel),
                default(string));


        /// <summary>
        /// The edit value property
        /// </summary>
        public static readonly BindableProperty LabelSourceTypeProperty =
            BindableProperty.Create(
                nameof(LabelSourceType),
                typeof(object),
                typeof(AxiosLocalizedLabel));


        [Description("Key of resource")]
        public string LabelTextKey
        {
            get => (string)GetValue(LabelTextKeyProperty);
            set => SetValue(LabelTextKeyProperty, value);
        }

        [Description("Label source type")]
        public Type LabelSourceType
        {
            get => (Type)GetValue(LabelSourceTypeProperty);
            set => SetValue(LabelSourceTypeProperty, value);
        }

        [Description("Label source")]
        public string LabelSource
        {
            get => (string)GetValue(LabelSourceProperty);
            set => SetValue(LabelSourceProperty, value);
        }

        /// <summary>
        /// Called when [label text key property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private static void OnLabelTextKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Label)bindable).Text = LocalizationService.GetResourceByKey((string)newValue);
        }
    }
}
