using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands
{
    public class CreateContractCommand:IRequest<bool>
    {
        public int UserId { get; set; }
        public string VinCode { get; set; }
        public double Price { get; set; }
        public double AmountPaid { get; set; }
        public double AmountToBePaid { get; set; }
        public DateTime Purchase { get; set; }
        public string Container { get; set; }
        public string CarManufacture { get; set; }
        public string CarModel { get; set; }
        public DateTime Year { get; set; }
    }
}
