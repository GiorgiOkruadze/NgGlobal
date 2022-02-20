using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands
{
    public class ImageSetAsMainCommand : IRequest<bool>
    {
        public int ImageId { get; set; }
        public int CarId { get; set; }
    }
}
