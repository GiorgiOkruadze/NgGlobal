using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class CompanyServiceImageDto
    {
        public int Id { get; set; }
        public int CompanyServiceId { get; set; }
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
    }
}
