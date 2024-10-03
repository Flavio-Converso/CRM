using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Entities
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Phone { get; set; }

        [Required]
        public required string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Foreign key and navigation property to CompanyType
        public int CompanyTypeId { get; set; }
        [ForeignKey("CompanyTypeId")]
        public required CompanyType CompanyType { get; set; }

        // Navigation property for one-to-many relationship with Appointments
        public ICollection<Appointment> Appointments { get; set; } = [];

        // Navigation property for many-to-many relationship with OfferedServices
        public ICollection<OfferedService> OfferedServices { get; set; } = [];
    }
}
