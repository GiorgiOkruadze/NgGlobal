using MediatR;
using Microsoft.AspNetCore.Identity;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationShared.Constants;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class RegisterAdminHandler : IRequestHandler<RegisterAdminCommand, int>
    {
        private readonly IUserRepository _userRepository = default;
        private readonly UserManager<User> _userManager;
        public RegisterAdminHandler(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<int> Handle(RegisterAdminCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                UserName = request.UserName,
                Email = request.Email,
            };

            var result = await _userRepository.RegistrationAsync(user, request.Password);
            await _userManager.AddToRoleAsync(user, UserType.Admin.ToString());

            return result;
        }


    }
}
