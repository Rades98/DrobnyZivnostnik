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

        [Required]
        public bool Deleted { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string IdentifyingNumber { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        public Guid? PlaceOfBusinessId { get; set; }
    }
}
