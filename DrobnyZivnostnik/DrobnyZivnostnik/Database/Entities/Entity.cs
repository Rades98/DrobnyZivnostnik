namespace DrobnyZivnostnik.Database.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Entity
    {
        [Required]
        public bool Deleted { get; set; }
    }
}
