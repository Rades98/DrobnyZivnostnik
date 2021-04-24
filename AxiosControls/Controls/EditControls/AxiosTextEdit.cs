namespace AxiosControls.Controls.EditControls
{
    using System;
    using System.ComponentModel;
    using Xamarin.Forms;

    public class AxiosTextEdit : AxiosBaseEditControl
    {
        #region Bindable properties

        /// <summary>
        /// The text edit property
        /// </summary>
        public static readonly BindableProperty TextEditProperty = BindableProperty.Create(
            nameof(TextEdit),
            typeof(string),
            typeof(AxiosTextEdit),
            propertyChanged: (bindable, oldValue, newValue) => ((AxiosTextEdit)bindable).OnTextChanged((string)oldValue, (string)newValue),
            defaultBindingMode: BindingMode.TwoWay);

        /// <summary>
        /// The keyboard property
        /// </summary>
        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(
                nameof(Keyboard),
                typeof(Keyboard),
                typeof(AxiosTextEdit),
                Keyboard.Default,
                coerceValue: (o, v) => (Keyboard)v ?? Keyboard.Default);

        [Description("Text edit")]
        public string TextEdit
        {
            get => (string)GetValue(TextEditProperty);
            set => SetValue(TextEditProperty, value);
        }

        [Description("Keyboard")]
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        #endregion Bindable properties

        public override View EditContent()
        {
            var entry = new Entry()
            {
                BindingContext = this,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontSize = FontSize,
                TextColor = FontColor,
            };

            entry.SetBinding(Entry.TextProperty, nameof(TextEdit), BindingMode.TwoWay);
            entry.SetBinding(Entry.KeyboardProperty, nameof(Keyboard));

            return entry;
        }

        #region Property changed methods

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

        #endregion Property changed methods
    }
}
