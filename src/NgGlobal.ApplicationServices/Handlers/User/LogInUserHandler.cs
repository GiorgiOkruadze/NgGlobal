using MediatR;
using NgGlobal.ApplicationServices.Authentication.Abstraction;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class LogInUserHandler : IRequestHandler<LogInUserCommand, string>
    {
        private readonly IUserRepository _userRepository = default;
        private readonly IJwtAuthenticationManager _authenticationManager = default;

        public LogInUserHandler(IUserRepository userRepository, IJwtAuthenticationManager authenticationManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
        }

        public async Task<string> Handle(LogInUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.LogInAsync(request.Email,request.Password);
            return _authenticationManager.Authenticate(result, request.Email);
        }
    }
}
