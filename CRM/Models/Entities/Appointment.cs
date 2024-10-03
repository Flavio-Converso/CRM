using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Entities
{
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public string? Location { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Foreign key and navigation property to CompanyWorker 
        public int CompanyWorkerId { get; set; }
        [ForeignKey("CompanyWorkerId")]
        public required CompanyWorker CompanyWorker { get; set; }

        // Foreign key and navigation property to Customer 
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public required Customer Customer { get; set; }

        // Navigation property for many-to-many relationship with Services
        public ICollection<OfferedService> OfferedServices { get; set; } = [];
    }
}
