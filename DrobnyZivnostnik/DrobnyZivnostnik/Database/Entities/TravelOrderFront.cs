namespace DrobnyZivnostnik.Database.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TravelOrderFront")]
    public class TravelOrderFront : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TravelOrderFrontId { get; set; }

        [Required]
        public string StartPlace { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public TimeSpan DepartmentTime { get; set; }

        [Required]
        public string PlaceOfMeeting { get; set; }

        [Required]
        public string MeetingPurpose { get; set; }

        public TimeSpan TravelLength { get; set; }

        [Required]
        public string EndPlace { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan ArrivalTime { get; set; }
    }
}
