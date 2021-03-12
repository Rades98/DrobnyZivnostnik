namespace DrobnyZivnostnik.Models.MasterPage
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class MasterPageItem
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the icon source.
        /// </summary>
        /// <value>
        /// The icon source.
        /// </value>
        public string IconSource { get; set; }

        /// <summary>
        /// Gets or sets the type of the target.
        /// </summary>
        /// <value>
        /// The type of the target.
        /// </value>
        public Type TargetType { get; set; }
    }
}
