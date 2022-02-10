using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands
{
    public class DeleteImageFromCarCommand : IRequest<bool>
    {
        public int CarId { get; set; }
        public int ImageId { get; set; }

    }
}
