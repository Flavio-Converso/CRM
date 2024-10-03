using CRM.Data;
using CRM.Interfaces;

namespace CRM.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DataContext _ctx;

        public AppointmentService(DataContext context)
        {
            _ctx = context;
        }

    }
}
