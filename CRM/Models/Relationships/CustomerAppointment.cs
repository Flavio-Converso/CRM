using CRM.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Relationships
{
    public class CustomerAppointment
    {
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public required Customer Customer { get; set; }

        public int AppointmentId { get; set; }

        [ForeignKey("AppointmentId")]
        public required Appointment Appointment { get; set; }
    }
}
