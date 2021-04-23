namespace AxiosControls.Controls
{
    using LocalizedControls;
    using System;
    using System.ComponentModel;
    using Xamarin.Forms;

    public class AxiosTextEdit : ContentView
    {
        public AxiosTextEdit()
        {
            SetContent();
        }

        private void SetContent()
        {
            //TODO Find out how to do it to make it nicer and clear.. 

            var label = new AxiosLocalizedLabel()
            {
                BindingContext = this,
                FontSize = 20,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Start
            };

            var entry = new Entry()
            {
                BindingContext = this,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            label.SetBinding(AxiosLocalizedLabel.LabelSourceTypeProperty, nameof(LabelSourceType), BindingMode.TwoWay);
            label.SetBinding(AxiosLocalizedLabel.LabelSourceProperty, nameof(LabelSource), BindingMode.TwoWay);

            entry.SetBinding(Entry.TextProperty, nameof(TextEdit), BindingMode.TwoWay);

            Content = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { label, entry }
            };
        }

        /// <summary>
        /// The label text key property
        /// </summary>
        public readonly BindableProperty LabelSourceProperty =
            BindableProperty.Create(
                nameof(LabelSource),
                typeof(string),
                typeof(AxiosTextEdit),
                default(string));


        /// <summary>
        /// The edit value property
        /// </summary>
        public static readonly BindableProperty LabelSourceTypeProperty =
            BindableProperty.Create(
                nameof(LabelSourceType),
                typeof(object),
                typeof(AxiosTextEdit));

        public static readonly BindableProperty HasErrorProperty =
            BindableProperty.Create(
                nameof(HasError),
                typeof(bool),
                typeof(AxiosTextEdit),
                propertyChanged:(bindable, value, newValue) => ((AxiosTextEdit)bindable).OnHasErrorChanged((bool)newValue));

        /// <summary>
        /// The text edit property
        /// </summary>
        public static readonly BindableProperty TextEditProperty = BindableProperty.Create(
            nameof(TextEdit),
            typeof(string),
            typeof(AxiosTextEdit),
            propertyChanged: (bindable, oldValue, newValue) => ((AxiosTextEdit)bindable).OnTextChanged((string)oldValue, (string)newValue),
            defaultBindingMode:BindingMode.TwoWay);

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

        [Description("Text edit")]
        public string TextEdit
        {
            get => (string)GetValue(TextEditProperty);
            set => SetValue(TextEditProperty, value);
        }

        [Description("Has Error")]
        public bool HasError
        {
            get => (bool) GetValue(HasErrorProperty);
            set => SetValue(HasErrorProperty, value);
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;

        protected virtual void OnTextChanged(string oldValue, string newValue)
        {
            TextChanged?.Invoke(this, new TextChangedEventArgs(oldValue, newValue));
        }

        protected virtual void OnHasErrorChanged(bool newValue)
        {
            BackgroundColor = newValue ? Color.LightCoral : Color.Transparent;
        }
    }
}
