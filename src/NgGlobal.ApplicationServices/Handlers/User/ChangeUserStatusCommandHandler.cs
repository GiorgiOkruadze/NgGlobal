using MediatR;
using Microsoft.AspNetCore.Identity;
using NgGlobal.ApplicationServices.Commands.User;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            user.Status = request.Status;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
