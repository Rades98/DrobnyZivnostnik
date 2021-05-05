namespace AxiosAnnotations.Localization
{
    using System;

    /// <summary>
    /// Attribute used for localization of property
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AxiosTextKeyAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the localization key.
        /// </summary>
        /// <value>
        /// The localization key.
        /// </value>
        public string LocalizationKey { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AxiosTextKeyAttribute"/> class.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        public AxiosTextKeyAttribute(string textKey)
        {
            LocalizationKey = textKey;
        }
    }
}
