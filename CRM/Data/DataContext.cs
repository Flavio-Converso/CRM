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
                .UsingEntity(j => j.ToTable("AppointmentServices"));

            // Company and OfferedService
            modelBuilder.Entity<Company>()
                .HasMany(c => c.OfferedServices)
                .WithMany(os => os.Companies)
                .UsingEntity(j => j.ToTable("CompanyOfferedServices"));

            // Customer and Appointment
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Appointments)
                .WithMany(a => a.Customers)
                .UsingEntity(j => j.ToTable("CustomerAppointments"));
        }
    }
}
