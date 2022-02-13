using MediatR;
using System;

namespace NgGlobal.ApplicationServices.Commands
{
    public class SetMailAboutCarCommand:IRequest<bool>
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
