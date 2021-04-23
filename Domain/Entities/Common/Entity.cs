namespace Domain.Entities.Common
{
    using System.ComponentModel.DataAnnotations;

    public class Entity
    {
        [Required]
        public bool Deleted { get; set; }
    }
}
