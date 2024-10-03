using CRM.Data;
using CRM.Interfaces;

namespace CRM.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _ctx;
        public CustomerService(DataContext dataContext)
        {
            _ctx = dataContext;
        }
    }
}
