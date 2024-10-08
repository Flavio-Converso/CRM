﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    public class CompanyWorker
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkerId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Surname { get; set; }

        [Required]
        public required string Position { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Phone { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Foreign key and navigation property to Company
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public required Company Company { get; set; }

        // Navigation property for one-to-many relationship with Appointments
        public ICollection<Appointment> Appointments { get; set; } = [];
    }
}
