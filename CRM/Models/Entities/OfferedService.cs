using CRM.Models.Relationships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Entities
{
    public class OfferedService
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferedServiceId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        // Navigation property for many-to-many relationship with Companies
        public ICollection<CompanyOfferedService> CompanyOfferedServices { get; set; } = [];

        // Navigation property for many-to-many relationship with Appointments
        public ICollection<AppointmentService> AppointmentServices { get; set; } = [];
    }
}
