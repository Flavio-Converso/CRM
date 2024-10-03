using Bogus;
using CRM.Models.Entities;

namespace CRM.Data
{
    public class DataSeeder
    {
        private readonly int _count;

        public DataSeeder(int count = 10)
        {
            _count = count;
        }
        public void SeedData(DataContext context)
        {
            ClearData(context); // Clear existing data
            SeedCustomers(context);
            SeedCompanyTypes(context);
            SeedCompanies(context);
            SeedCompanyWorkers(context);
            SeedAppointments(context);
            SeedAvailability(context);
            SeedOfferedServices(context);
            SeedCompanyOfferedServices(context);
            SeedAppointmentServices(context);
        }

        public void ClearData(DataContext context)
        {
            context.Customers.RemoveRange(context.Customers);
            context.Appointments.RemoveRange(context.Appointments);
            context.CompanyWorkers.RemoveRange(context.CompanyWorkers);
            context.Companies.RemoveRange(context.Companies);
            context.CompanyTypes.RemoveRange(context.CompanyTypes);
            context.OfferedServices.RemoveRange(context.OfferedServices);
            context.SaveChanges();
        }
        public void SeedAppointments(DataContext context)
        {
            var customers = context.Customers.ToList();
            var companyWorkers = context.CompanyWorkers.ToList();
            var appointmentFaker = new Faker<Appointment>()
                .RuleFor(a => a.Title, f => f.Lorem.Sentence())
                .RuleFor(a => a.Date, f => f.Date.Future())
                .RuleFor(a => a.StartTime, f => f.Date.Timespan())
                .RuleFor(a => a.EndTime, f => f.Date.Timespan())
                .RuleFor(a => a.Location, f => f.Address.FullAddress())
                .RuleFor(a => a.Notes, f => f.Lorem.Paragraph())
                .RuleFor(a => a.CreatedAt, f => DateTime.Now)
                .RuleFor(a => a.UpdatedAt, f => DateTime.Now)
                .RuleFor(c => c.CompanyWorkerId, f => f.PickRandom(companyWorkers).WorkerId)
                .RuleFor(a => a.CustomerId, f => f.PickRandom(customers).CustomerId);
            var appointments = appointmentFaker.Generate(_count);
            context.Appointments.AddRange(appointments);
            context.SaveChanges();
        }


        public void SeedAvailability(DataContext context)
        {
            var companyWorkers = context.CompanyWorkers.ToList();
            var availabilityFaker = new Faker<Availability>()
                .RuleFor(a => a.Day, f => f.PickRandom<DayOfWeek>())
                .RuleFor(a => a.StartTime, f => f.Date.Timespan())
                .RuleFor(a => a.EndTime, f => f.Date.Timespan())
                .RuleFor(c => c.CompanyWorkerId, f => f.PickRandom(companyWorkers).WorkerId);
            var availabilities = availabilityFaker.Generate(_count);
            context.Availabilities.AddRange(availabilities);
            context.SaveChanges();
        }


        public void SeedCompanies(DataContext context)
        {
            var companyTypes = context.CompanyTypes.ToList();
            var companyFaker = new Faker<Company>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Address, f => f.Address.StreetAddress())
                .RuleFor(c => c.CreatedAt, f => DateTime.Now)
                .RuleFor(c => c.UpdatedAt, f => DateTime.Now)
                .RuleFor(c => c.CompanyTypeId, f => f.PickRandom(companyTypes).CompanyTypeId);

            var companies = companyFaker.Generate(_count);
            context.Companies.AddRange(companies);
            context.SaveChanges();
        }


        public void SeedCompanyTypes(DataContext context)
        {
            var typeFaker = new Faker<CompanyType>()
                .RuleFor(ct => ct.Name, f => f.Lorem.Sentence())
                .RuleFor(ct => ct.Description, f => f.Lorem.Paragraph())
                .RuleFor(ct => ct.CreatedAt, f => DateTime.Now)
                .RuleFor(ct => ct.UpdatedAt, f => DateTime.Now);

            var types = typeFaker.Generate(_count);
            context.CompanyTypes.AddRange(types);
            context.SaveChanges();
        }


        public void SeedCompanyWorkers(DataContext context)
        {
            var companies = context.Companies.ToList();
            var workerFaker = new Faker<CompanyWorker>()
                .RuleFor(w => w.Name, f => f.Name.FirstName())
                .RuleFor(w => w.Surname, f => f.Name.LastName())
                .RuleFor(w => w.Position, f => f.Name.JobTitle())
                .RuleFor(w => w.Email, f => f.Internet.Email())
                .RuleFor(w => w.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(w => w.CreatedAt, f => DateTime.Now)
                .RuleFor(w => w.UpdatedAt, f => DateTime.Now)
                .RuleFor(c => c.CompanyId, f => f.PickRandom(companies).CompanyId);
            var workers = workerFaker.Generate(_count);
            context.CompanyWorkers.AddRange(workers);
            context.SaveChanges();
        }


        public void SeedCustomers(DataContext context)
        {
            var customerFaker = new Faker<Customer>()
                .RuleFor(c => c.Name, f => f.Name.FirstName())
                .RuleFor(c => c.Surname, f => f.Name.LastName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.Address, f => f.Address.StreetAddress())
                .RuleFor(c => c.CreatedAt, f => DateTime.Now)
                .RuleFor(c => c.UpdatedAt, f => DateTime.Now);

            var customers = customerFaker.Generate(_count);
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }


        public void SeedOfferedServices(DataContext context)
        {
            var serviceFaker = new Faker<OfferedService>()
                .RuleFor(os => os.Name, f => f.Commerce.ProductName())
                .RuleFor(os => os.Description, f => f.Lorem.Sentence())
                .RuleFor(os => os.Price, f => decimal.Parse(f.Commerce.Price(10, 100))) // Generates a price between 10 and 100
                .RuleFor(os => os.CreatedAt, f => DateTime.Now)
                .RuleFor(os => os.UpdatedAt, f => DateTime.Now);

            var services = serviceFaker.Generate(_count);
            context.OfferedServices.AddRange(services);
            context.SaveChanges();
        }

        public void SeedCompanyOfferedServices(DataContext context)
        {
            var companies = context.Companies.ToList();
            var services = context.OfferedServices.ToList();
            var companyOfferedServices = new List<(int CompanyId, int OfferedServiceId)>();

            foreach (var company in companies)
            {
                var assignedServices = services.OrderBy(s => Guid.NewGuid()).Take(new Random().Next(1, _count)).ToList();
                foreach (var service in assignedServices)
                {
                    company.OfferedServices.Add(service);
                }
            }

            context.SaveChanges();
        }

        public void SeedAppointmentServices(DataContext context)
        {
            var appointments = context.Appointments.ToList();
            var services = context.OfferedServices.ToList();

            foreach (var appointment in appointments)
            {
                var assignedServices = services.OrderBy(s => Guid.NewGuid()).Take(new Random().Next(1, _count)).ToList();
                foreach (var service in assignedServices)
                {
                    appointment.OfferedServices.Add(service);
                }
            }

            context.SaveChanges();
        }

    }
}
