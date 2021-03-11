
namespace DrobnyZivnostnik.Models.User
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Address;


    public class UserModel : IModel
    {
        public Guid UserId { get; set; }

        public bool IsActive { get; set; }

        public bool Deleted { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        //IČO
        public string IdentifyingNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public Guid AddressId { get; set; }

        public Guid PlaceOfBusinessId { get; set; }

        public string ImagePath { get; set; }

        public AddressModel Address { get; set; }

        public AddressModel PlaceOfBusiness { get; set; }
    }
}
