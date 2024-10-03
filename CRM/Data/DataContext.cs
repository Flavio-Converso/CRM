using CRM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyWorker> CompanyWorkers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OfferedService> OfferedServices { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationships

            // Appointment and OfferedService
            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.OfferedServices)
                .WithMany(os => os.Appointments)
                .UsingEntity<Dictionary<string, object>>(
                    "AppointmentServices",
                    j => j
                        .HasOne<OfferedService>()
                        .WithMany()
                        .HasForeignKey("OfferedServiceId")
                        .HasConstraintName("FK_AppointmentServices_OfferedServices"),
                    j => j
                        .HasOne<Appointment>()
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .HasConstraintName("FK_AppointmentServices_Appointments"),
                    j =>
                    {
                        j.HasKey("AppointmentId", "OfferedServiceId");
                        j.ToTable("AppointmentServices");
                    });

            // Company and OfferedService
            modelBuilder.Entity<Company>()
                .HasMany(c => c.OfferedServices)
                .WithMany(os => os.Companies)
                .UsingEntity<Dictionary<string, object>>(
                    "CompanyOfferedServices",
                    j => j
                        .HasOne<OfferedService>()
                        .WithMany()
                        .HasForeignKey("OfferedServiceId")
                        .HasConstraintName("FK_CompanyOfferedServices_OfferedServices"),
                    j => j
                        .HasOne<Company>()
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_CompanyOfferedServices_Companies"),
                    j =>
                    {
                        j.HasKey("CompanyId", "OfferedServiceId");
                        j.ToTable("CompanyOfferedServices");
                    });

            // Customer and Appointment
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Appointments)
                .WithMany(a => a.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerAppointments",
                    j => j
                        .HasOne<Appointment>()
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .HasConstraintName("FK_CustomerAppointments_Appointments"),
                    j => j
                        .HasOne<Customer>()
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CustomerAppointments_Customers"),
                    j =>
                    {
                        j.HasKey("CustomerId", "AppointmentId");
                        j.ToTable("CustomerAppointments");
                    });
        }
    }
}
