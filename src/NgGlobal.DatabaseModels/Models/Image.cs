using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class Image : BaseEntity
    {
        public int? CarId { get; set; }
        public bool IsMainImage { get; set; }
        public string ImageName { get; set; }
        public string PublicId { get; set; }
    }
}
