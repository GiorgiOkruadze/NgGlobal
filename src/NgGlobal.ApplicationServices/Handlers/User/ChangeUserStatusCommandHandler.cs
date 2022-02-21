using MediatR;
using Microsoft.AspNetCore.Identity;
using NgGlobal.ApplicationServices.Commands.User;
using NgGlobal.DatabaseModels.Constants;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers.Users
{
    public class ChangeUserStatusCommandHandler : IRequestHandler<ChangeUserStatusCommand, bool>
    {

        private readonly UserManager<User> _userManager;

        public ChangeUserStatusCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(ChangeUserStatusCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            user.Status = user.Status == UserStatus.Activated ? UserStatus.Deactivated : UserStatus.Activated;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
