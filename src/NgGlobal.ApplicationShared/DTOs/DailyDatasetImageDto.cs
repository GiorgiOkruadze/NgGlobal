using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class DailyDatasetImageDto
    {
        public int Id { get; set; }
        public int DailyDatasetId { get; set; }
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
    }
}
