using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class DailyDatasetImage : BaseEntity
    {
        public int DailyDatasetId { get; set; }
        public DailyDataset DailyDataset { get; set; }
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }

    }
}
