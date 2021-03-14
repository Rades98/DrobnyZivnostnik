namespace DrobnyZivnostnik.Controls
{
    using System.ComponentModel;
    using Xamarin.Forms;

    /// <summary>
    /// Custom label with localization
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Label" />
    class LocalizedLabel : Label
    {
        //TODO Attributes + handling

        /// <summary>
        /// The label text key property
        /// </summary>
        public static readonly BindableProperty LabelTextKeyProperty = 
            BindableProperty.Create(
                nameof(LabelTextKey), 
                typeof(string), 
                typeof(LocalizedLabel), 
                default(string), 
                propertyChanged:OnLabelTextKeyPropertyChanged);
        
        [Description("Key of resource")]
        public string LabelTextKey
        {
            get => (string)GetValue(LabelTextKeyProperty);
            set => SetValue(LabelTextKeyProperty, value);
        }

        /// <summary>
        /// Called when [label text key property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        static void OnLabelTextKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Label)bindable).Text = Utils.GetResourceByKey((string)newValue);
        }
    }
}
