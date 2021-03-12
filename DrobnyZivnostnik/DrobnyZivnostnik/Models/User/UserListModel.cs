namespace DrobnyZivnostnik.Models.User
{
    using System;

    /// <summary>
    /// User list model
    /// model for user selection menu
    /// </summary>
    public class UserListModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifying number.
        /// </summary>
        /// <value>
        /// The identifying number.
        /// </value>
        public string IdentifyingNumber { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        public string ImagePath { get; set; }
    }
}
