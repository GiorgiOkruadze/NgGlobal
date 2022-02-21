using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadAllAdminsHandler:IRequestHandler<ReadAllAdminsQuery,List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository = default;
        public ReadAllAdminsHandler(IUserRepository userRepository, UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(ReadAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var admins = await _userRepository.GetAllUsersAsync(new List<string>()
            {
                "Contracts",
                "Cars"
            });

            var filteredAdmins = new List<User>();
            foreach(var user in admins)
            {
                var role = await _userManager.GetRolesAsync(user);
                if (role.Contains("Admin")){
                    filteredAdmins.Add(user);
                }
            }
            

            return _mapper.Map<List<UserDto>>(filteredAdmins);
        }
    }
}
