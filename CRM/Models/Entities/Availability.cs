using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Entities
{
    public class Availability
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvailabilityId { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        // Foreign key and navigation property to CompanyWorker
        public int CompanyWorkerId { get; set; }
        [ForeignKey("CompanyWorkerId")]
        public required CompanyWorker CompanyWorker { get; set; }
    }
}
