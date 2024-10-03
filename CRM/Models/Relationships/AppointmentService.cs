using CRM.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Relationships
{
    public class AppointmentService
    {
        public int AppointmentId { get; set; }

        [ForeignKey("AppointmentId")]
        public required Appointment Appointment { get; set; }

        public int OfferedServiceId { get; set; }

        [ForeignKey("OfferedServiceId")]
        public required OfferedService OfferedService { get; set; }
    }
}
