using MediatR;

namespace NgGlobal.ApplicationServices.Commands
{
    public class LogInUserCommand:IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
