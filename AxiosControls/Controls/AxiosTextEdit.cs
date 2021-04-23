namespace AxiosControls.Controls
{
    using LocalizedControls;
    using System;
    using System.ComponentModel;
    using Interfaces;
    using Xamarin.Forms;

    public class AxiosTextEdit : ContentView, ILocalizedValidableControl
    {
        public AxiosTextEdit()
        {
            SetContent();
        }

        #region Bindable properties

        /// <inheritdoc cref="ILocalizedValidableControl"/>
        public static readonly BindableProperty HasErrorProperty =
            BindableProperty.Create(
                nameof(HasError),
                typeof(bool),
                typeof(AxiosTextEdit),
                propertyChanged: (bindable, value, newValue) => ((AxiosTextEdit)bindable).OnHasErrorChanged((bool)newValue));

        /// <inheritdoc cref="ILocalizedValidableControl"/>
        public readonly BindableProperty LabelSourceProperty =
            BindableProperty.Create(
                nameof(LabelSource),
                typeof(string),
                typeof(AxiosTextEdit),
                default(string));


        /// <inheritdoc cref="ILocalizedValidableControl"/>
        public static readonly BindableProperty LabelSourceTypeProperty =
            BindableProperty.Create(
                nameof(LabelSourceType),
                typeof(object),
                typeof(AxiosTextEdit));


        /// <summary>
        /// The text edit property
        /// </summary>
        public static readonly BindableProperty TextEditProperty = BindableProperty.Create(
            nameof(TextEdit),
            typeof(string),
            typeof(AxiosTextEdit),
            propertyChanged: (bindable, oldValue, newValue) => ((AxiosTextEdit)bindable).OnTextChanged((string)oldValue, (string)newValue),
            defaultBindingMode: BindingMode.TwoWay);

        /// <inheritdoc cref="ILocalizedValidableControl"/>
        [Description("Has Error")]
        public bool HasError
        {
            get => (bool)GetValue(HasErrorProperty);
            set => SetValue(HasErrorProperty, value);
        }

        /// <inheritdoc cref="ILocalizedValidableControl"/>
        [Description("Label source type")]
        public Type LabelSourceType
        {
            get => (Type)GetValue(LabelSourceTypeProperty);
            set => SetValue(LabelSourceTypeProperty, value);
        }

        /// <inheritdoc cref="ILocalizedValidableControl"/>
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

        #endregion Bindable properties

        private void SetContent()
        {
            //TODO Find out how to do it to make it nicer and clear.. (optional)

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

        public event EventHandler<TextChangedEventArgs> TextChanged;

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnTextChanged(string oldValue, string newValue)
        {
            TextChanged?.Invoke(this, new TextChangedEventArgs(oldValue, newValue));
        }

        /// <inheritdoc cref="ILocalizedValidableControl"/>
        protected virtual void OnHasErrorChanged(bool newValue)
        {
            BackgroundColor = newValue ? Color.LightCoral : Color.Transparent;
        }
    }
}
