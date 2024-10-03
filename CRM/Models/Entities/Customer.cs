﻿using CRM.Models.Relationships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Entities
{
    public class Customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Phone { get; set; }

        [Required]
        public required string Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Navigation property for many-to-many relationship with Appointments
        public ICollection<CustomerAppointment> CustomerAppointments { get; set; } = [];
    }
}
