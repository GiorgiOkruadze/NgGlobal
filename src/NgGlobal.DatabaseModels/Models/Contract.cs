using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.DatabaseModels.Models
{
    public class Contract:BaseEntity
    {
        public int UserId { get; set; }
        public string VinCode { get; set; }
        public double Price { get; set; }
        public double AmountPaid { get; set; }
        public double AmountToBePaid  { get; set; }
        public DateTime Purchase { get; set; }
        public string Container { get; set; }
        public string CarManufacture { get;set; }
        public string CarModel { get; set; }
        public DateTime Year { get; set; }
    }
}
