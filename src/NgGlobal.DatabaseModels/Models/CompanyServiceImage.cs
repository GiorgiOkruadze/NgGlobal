using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class CompanyServiceImage : BaseEntity
    {
        public int CompanyServiceId { get; set; }
        public CompanyService CompanyService { get; set; }
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
    }
}
