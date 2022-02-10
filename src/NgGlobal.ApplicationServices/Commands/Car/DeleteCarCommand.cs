
using MediatR;

namespace NgGlobal.ApplicationServices.Commands
{
    public class DeleteCarCommand:IRequest<bool>
    {
        public int CarId { get; set; }
    }
}
