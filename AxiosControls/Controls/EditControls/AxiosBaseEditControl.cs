namespace AxiosControls.Controls.EditControls
{
    using System;
    using System.ComponentModel;
    using Converters;
    using LocalizedControls;
    using Xamarin.Forms;

    public abstract class AxiosBaseEditControl : StackLayout
    {
        public abstract View EditContent();

        protected AxiosBaseEditControl()
        {
            Children.Add(SetContent());
        }

        #region Content

        private View SetContent()
        {
            var frame = new Frame()
            {
                BackgroundColor = Color.Transparent,
                BindingContext = this,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Children =
                    {
                        new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = { LocalizedLabel(), EditContent() }
                        },
                        ErrorLayout()
                    }
                }
            };

            frame.SetBinding(Frame.BorderColorProperty, nameof(ErrorMessage), converter: new HasDataColorConverter(ErrorFontColor));

            return frame;
        }

        private StackLayout ErrorLayout()
        {
            var errorLabel = new AxiosLocalizedLabel()
            {
                BindingContext = this,
                FontSize = ErrorFontSize,
                TextColor = ErrorFontColor,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };

            errorLabel.SetBinding(AxiosLocalizedLabel.LabelTextKeyProperty, nameof(ErrorMessage));
            errorLabel.SetBinding(AxiosLocalizedLabel.IsVisibleProperty, nameof(ErrorMessage), converter: new HasDataBoolConverter());
            errorLabel.SetBinding(AxiosLocalizedLabel.HeightRequestProperty, nameof(ErrorMessage), converter: new HasDataHeightRequestConverter());

            var stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children = {errorLabel}
            };

            stackLayout.SetBinding(StackLayout.HeightRequestProperty, nameof(ErrorMessage), converter: new HasDataHeightRequestConverter());

            return stackLayout;
        }

        private AxiosLocalizedLabel LocalizedLabel()
        {
            var label = new AxiosLocalizedLabel()
            {
                BindingContext = this,
                FontSize = FontSize,
                TextColor = FontColor,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Start
            };

            label.SetBinding(AxiosLocalizedLabel.LabelSourceTypeProperty, nameof(LabelSourceType));
            label.SetBinding(AxiosLocalizedLabel.LabelSourceProperty, nameof(LabelSource));

            return label;
        }

        #endregion Content

        #region Bindable properties

        /// <summary>
        /// The error message property
        /// </summary>
        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(AxiosBaseEditControl), default(string), propertyChanged: (bindable, oldValue, newValue) => ((AxiosBaseEditControl)bindable).OnErrorTextChanged((string)oldValue, (string)newValue), defaultBindingMode: BindingMode.TwoWay);

        /// <summary>
        /// The Error font color property
        /// </summary>
        public static readonly BindableProperty ErrorFontColorProperty = BindableProperty.Create(nameof(ErrorFontColor), typeof(Color), typeof(AxiosBaseEditControl));

        /// <summary>
        /// The Error font size property
        /// </summary>
        public static readonly BindableProperty ErrorFontSizeProperty = BindableProperty.Create(nameof(ErrorFontSize), typeof(int), typeof(AxiosBaseEditControl));

        /// <summary>
        /// The font color property
        /// </summary>
        public static readonly BindableProperty FontColorProperty = BindableProperty.Create(nameof(FontColor), typeof(Color), typeof(AxiosBaseEditControl));

        /// <summary>
        /// The font size property
        /// </summary>
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(int), typeof(AxiosBaseEditControl));

        /// <summary>
        /// The label source property
        /// </summary>
        public readonly BindableProperty LabelSourceProperty = BindableProperty.Create(nameof(LabelSource), typeof(string), typeof(AxiosBaseEditControl), default(string));

        /// <summary>
        /// The label source type property
        /// </summary>
        public static readonly BindableProperty LabelSourceTypeProperty = BindableProperty.Create(nameof(LabelSourceType), typeof(object), typeof(AxiosBaseEditControl));

        #endregion Bindable properties


        #region Properties

        /// <summary>
        /// Gets or sets error message
        /// </summary>
        [Description("Error message")]
        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set => SetValue(ErrorMessageProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        [Description("Error font color")]
        public Color ErrorFontColor
        {
            get => (Color)GetValue(ErrorFontColorProperty);
            set => SetValue(ErrorFontColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        [Description("Error font size")]
        public int ErrorFontSize
        {
            get => (int)GetValue(ErrorFontSizeProperty);
            set => SetValue(ErrorFontSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the font.
        /// </summary>
        [Description("Font color")]
        public Color FontColor
        {
            get => (Color)GetValue(FontColorProperty);
            set => SetValue(FontColorProperty, value);
        }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        [Description("Font size")]
        public int FontSize
        {
            get => (int)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the type of the label source.
        /// </summary>
        [Description("Label source type")]
        public Type LabelSourceType
        {
            get => (Type)GetValue(LabelSourceTypeProperty);
            set => SetValue(LabelSourceTypeProperty, value);
        }

        /// <summary>
        /// Gets or sets the label source.
        /// </summary>
        [Description("Label source")]
        public string LabelSource
        {
            get => (string)GetValue(LabelSourceProperty);
            set => SetValue(LabelSourceProperty, value);
        }

        #endregion Properties

        public event EventHandler<TextChangedEventArgs> ErrorTextChanged;

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnErrorTextChanged(string oldValue, string newValue)
        {
            ErrorTextChanged?.Invoke(this, new TextChangedEventArgs(oldValue, newValue));
        }
    }
}
