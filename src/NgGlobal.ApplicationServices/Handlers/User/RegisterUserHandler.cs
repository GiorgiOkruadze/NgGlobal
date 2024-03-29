﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationShared.Constants;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository = default;
        private readonly UserManager<User> _userManager;
        public RegisterUserHandler(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                UserName = request.UserName,
                Email = request.Email,
                Status = DatabaseModels.Constants.UserStatus.Activated
            };

            var result = await _userRepository.RegistrationAsync(user, request.Password);
            await _userManager.AddToRoleAsync(user, UserType.Customer.ToString());

            return result;
        }


    }
}
