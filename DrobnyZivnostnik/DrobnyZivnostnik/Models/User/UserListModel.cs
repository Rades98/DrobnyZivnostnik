namespace DrobnyZivnostnik.Models.User
{
    using System;

    public class UserListModel
    {
        public string Name { get; set; }

        public string IdentifyingNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImagePath { get; set; }
    }
}
