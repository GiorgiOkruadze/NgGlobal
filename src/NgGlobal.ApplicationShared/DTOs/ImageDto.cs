using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationShared.DTOs
{
    public class ImageDto
    {
        public int? Id { get; set; }
        public int? CarId { get; set; }
        public bool IsMainImage { get; set; }
        public string ImageName { get; set; }
    }
}
