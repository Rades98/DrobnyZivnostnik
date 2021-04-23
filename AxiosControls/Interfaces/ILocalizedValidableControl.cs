namespace AxiosControls.Interfaces
{
    using System;
    using System.ComponentModel;
    using Controls;
    using Xamarin.Forms;

    internal interface ILocalizedValidableControl
    {
        public static readonly BindableProperty LabelSourceProperty;


        /// <summary>
        /// The edit value property
        /// </summary>
        public static readonly BindableProperty LabelSourceTypeProperty;

        /// <summary>
        /// The has error property
        /// </summary>
        public static readonly BindableProperty HasErrorProperty;


        /// <summary>
        /// Gets or sets the type of the label source.
        /// </summary>
        /// <value>
        /// The type of the label source.
        /// </value>
        [Description("Label source type")] 
        public Type LabelSourceType { get; set; }

        /// <summary>
        /// Gets or sets the label source.
        /// </summary>
        /// <value>
        /// The label source.
        /// </value>
        [Description("Label source")]
        public string LabelSource { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        [Description("Has Error")]
        public bool HasError { get; set; }

        /// <summary>
        /// The background color
        /// </summary>
        public Color BackgroundColor { get; set; } // This is here only for obtaining specified behaviour

        /// <summary>
        /// Called when [has error changed].
        /// </summary>
        /// <param name="newValue">if set to <c>true</c> [new value].</param>
        protected virtual void OnHasErrorChanged(bool newValue)
        {
            BackgroundColor = newValue ? Color.LightCoral : Color.Transparent;
        }
    }
}
