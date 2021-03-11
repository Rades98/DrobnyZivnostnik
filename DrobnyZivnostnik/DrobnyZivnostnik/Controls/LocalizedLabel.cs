namespace DrobnyZivnostnik.Controls
{
    using Xamarin.Forms;

    class LocalizedLabel : Label
    {
        public static readonly BindableProperty LabelTextKeyProperty = 
            BindableProperty.Create(
                nameof(LabelTextKey), 
                typeof(string), 
                typeof(LocalizedLabel), 
                default(string), 
                propertyChanged:OnLabelTextKeyPropertyChanged);
        
        public string LabelTextKey
        {
            get => (string)GetValue(LabelTextKeyProperty);
            set => SetValue(LabelTextKeyProperty, value);
        }

        static void OnLabelTextKeyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((Label)bindable).Text = Utils.GetResourceByKey((string)newValue);
        }
    }
}
