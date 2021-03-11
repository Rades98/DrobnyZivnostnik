namespace DrobnyZivnostnik.Database.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        public bool IsActive { get; set; }

        public bool Deleted { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdentifyingNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImagePath { get; set; }

        public Guid AddressId { get; set; }

        public Guid? PlaceOfBusinessId { get; set; }
    }
}
