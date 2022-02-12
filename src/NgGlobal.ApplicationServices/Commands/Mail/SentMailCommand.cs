using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Commands
{
    public class SentMailCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ReasonForEnquiry { get;set; }
        public string Message { get; set; }
    }
}
