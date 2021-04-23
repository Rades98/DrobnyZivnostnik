namespace Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    [Table("User")]
    public class User : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

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

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
