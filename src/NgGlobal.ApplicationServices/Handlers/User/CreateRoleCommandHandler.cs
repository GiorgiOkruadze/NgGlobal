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

namespace NgGlobal.ApplicationServices.Handlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Unit>
    {
        private readonly RoleManager<UserRole> _roleMananger;

        public CreateRoleCommandHandler(RoleManager<UserRole> roleManager)
        {
            _roleMananger = roleManager;
        }

        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var existRole = await _roleMananger.FindByNameAsync(request.Role.ToString());

            if (existRole == null)
            {
                await _roleMananger.CreateAsync(new UserRole
                {
                    Name = request.Role.ToString()
                });
            }

            return Unit.Value;
        }
    }
}
