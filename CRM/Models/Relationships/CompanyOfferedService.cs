using CRM.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Models.Relationships
{
    public class CompanyOfferedService
    {
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public required Company Company { get; set; }

        public int OfferedServiceId { get; set; }

        [ForeignKey("OfferedServiceId")]
        public required OfferedService OfferedService { get; set; }
    }
}
