using CRM.Data;
using CRM.Interfaces;

namespace CRM.Services
{
    public class OfferedServicesService : IOfferedServicesService
    {
        private readonly DataContext _ctx;
        public OfferedServicesService(DataContext dataContext)
        {
            _ctx = dataContext;
        }
    }
}
