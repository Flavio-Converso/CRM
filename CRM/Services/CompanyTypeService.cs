using CRM.Data;
using CRM.Interfaces;

namespace CRM.Services
{
    public class CompanyTypeService : ICompanyTypeService
    {
        private readonly DataContext _ctx;
        public CompanyTypeService(DataContext dataContext)
        {
            _ctx = dataContext;
        }
    }
}
