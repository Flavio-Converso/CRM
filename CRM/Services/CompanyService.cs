using CRM.Data;
using CRM.Interfaces;

namespace CRM.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly DataContext _ctx;

        public CompanyService(DataContext dataContext)
        {
            _ctx = dataContext;
        }
    }
}
