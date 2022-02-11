using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands
{
    public class DeleteCompanyServiceCommand:IRequest<bool>
    {
        public int DailyDatasetId { get; set; }
    }
}
