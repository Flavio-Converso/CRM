using CRM.Data;
using CRM.Interfaces;
namespace CRM.Services
{
    public class CompanyWorkerService : ICompanyWorkerService
    {
        private readonly DataContext _ctx;
        public CompanyWorkerService(DataContext dataContext)
        {
            _ctx = dataContext;
        }
    }
}
