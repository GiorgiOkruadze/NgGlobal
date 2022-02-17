using MediatR;
using Microsoft.AspNetCore.Identity;
using NgGlobal.ApplicationServices.Authentication.Abstraction;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class LogInUserHandler : IRequestHandler<LogInUserCommand, string>
    {
        private readonly IUserRepository _userRepository = default;
        private readonly IJwtAuthenticationManager _authenticationManager = default;
        private readonly UserManager<User> _userManager;
        public LogInUserHandler(IUserRepository userRepository, IJwtAuthenticationManager authenticationManager, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
            _userManager = userManager;
        }

        public async Task<string> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.LogInAsync(request.Email, request.Password);
            var user = await _userManager.FindByEmailAsync(request.Email);
            var roles = await _userManager.GetRolesAsync(user);
            return _authenticationManager.Authenticate(result,user.Id, request.Email ,user.UserName, roles.ToList());
        }
    }
}
