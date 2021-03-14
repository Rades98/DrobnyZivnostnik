namespace DrobnyZivnostnik.Database.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Vehicle")]
    public class Vehicle : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid VehicleId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string NumberPlate { get; set; }

        [Required]
        public double FuelConsumption { get; set; }

        [Required]
        public string FuelType { get; set; }

        public string ImagePath { get; set; }

        public bool Deleted { get; set; }
    }
}
