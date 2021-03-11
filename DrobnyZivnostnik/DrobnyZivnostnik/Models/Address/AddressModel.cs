namespace DrobnyZivnostnik.Models.Address
{
    using System;

    public class AddressModel : IModel
    {
        public Guid AddressId { get; set; }

        public bool Deleted { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string ZipCode { get; set; }
    }
}
