using CRM.Data;
using CRM.Interfaces;

namespace CRM.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly DataContext _ctx;

        public AvailabilityService(DataContext dataContext)
        {
            _ctx = dataContext;
        }
    }
}
