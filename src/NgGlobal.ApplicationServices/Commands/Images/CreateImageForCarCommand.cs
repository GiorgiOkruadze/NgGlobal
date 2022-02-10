using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands
{
    public class CreateImageForCarCommand : IRequest<bool>
    {
        public IFormFile Image { get; set; }
        public int CarId { get; set; }

    }
}
