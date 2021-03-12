
namespace DrobnyZivnostnik.Models.User
{
    using System;
    using Address;

    /// <summary>
    /// USer model
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UserModel"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        public string Surname { get; set; }

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
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>
        public Guid AddressId { get; set; }

        /// <summary>
        /// Gets or sets the place of business identifier.
        /// </summary>
        /// <value>
        /// The place of business identifier.
        /// </value>
        public Guid PlaceOfBusinessId { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public AddressModel Address { get; set; }

        /// <summary>
        /// Gets or sets the place of business.
        /// </summary>
        /// <value>
        /// The place of business.
        /// </value>
        public AddressModel PlaceOfBusiness { get; set; }
    }
}
