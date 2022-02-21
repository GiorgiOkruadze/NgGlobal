using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailCommand, List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository = default;
        public GetUserByEmailHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUserByEmailCommand request, CancellationToken cancellationToken)
        {
            var currentUsers = await _userRepository.GetUserByEmailAsync(request.Email);

            return _mapper.Map<List<UserDto>>(currentUsers);
        }
    }
}
