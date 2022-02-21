using MediatR;

namespace NgGlobal.ApplicationServices.Commands.User
{
    public class ChangeUserStatusCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
}
