using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Queries;
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
    public class ReadAllUsersHandler:IRequestHandler<ReadAllUsersQuery,List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository = default;
        public ReadAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(ReadAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAllUsersAsync(new List<string>()
            {
                "DriveTrainTranslations",
                "DriveTrainTranslations.Language",
                "FuelTypeTranslations",
                "FuelTypeTranslations.Language",
                "TransmissionTranslations",
                "TransmissionTranslations.Language",
                "Images"
            });

            return _mapper.Map<List<UserDto>>(user);
        }
    }
}
