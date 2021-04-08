namespace DrobnyZivnostnik.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using Address;
    using Annotations;
    using Vehicle;

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
        [AxiosTextKey("Axios.Models.UserModel.UserId")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UserModel"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.Deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.Surname")]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the identifying number.
        /// </summary>
        /// <value>
        /// The identifying number.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.IdentifyingNumber")]
        public string IdentifyingNumber { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.CreationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the address identifier.
        /// </summary>
        /// <value>
        /// The address identifier.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.AddressId")]
        public Guid? AddressId { get; set; }

        /// <summary>
        /// Gets or sets the place of business identifier.
        /// </summary>
        /// <value>
        /// The place of business identifier.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.PlaceOfBusinessId")]
        public Guid? PlaceOfBusinessId { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.ImagePath")]
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.Address")]
        public AddressModel Address { get; set; }

        /// <summary>
        /// Gets or sets the place of business.
        /// </summary>
        /// <value>
        /// The place of business.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.PlaceOfBusiness")]
        public AddressModel PlaceOfBusiness { get; set; }

        /// <summary>
        /// Gets or sets the vehicles.
        /// </summary>
        /// <value>
        /// The vehicles.
        /// </value>
        [AxiosTextKey("Axios.Models.UserModel.Vehicles")]
        public ObservableCollection<VehicleModel> Vehicles { get; set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [NotMapped]
        [AxiosTextKey("Axios.Models.UserModel.FullName")]
        public string FullName => $"{Name} {Surname}";

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        [AxiosRequired]
        [AxiosTextKey("Axios.Models.UserModel.PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
