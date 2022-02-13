using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class CarInfoMail:BaseEntity
    {
        public string FullName { get; set; }
        public DateTime Year { get; set; }
        public string CarMark { get; set; }
        public string CarModel { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
