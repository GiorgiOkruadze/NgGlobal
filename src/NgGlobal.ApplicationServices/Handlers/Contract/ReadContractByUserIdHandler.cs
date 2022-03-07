using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadContractsByUserIdHandler : IRequestHandler<ReadContractsByUserIdQuery, List<ContractDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Contract> _contractRepository;

        public ReadContractsByUserIdHandler(IRepository<Contract> contractRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
        }

        public async Task<List<ContractDto>> Handle(ReadContractsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var allContracts = await _contractRepository.GetAsync(o => o.UserId == request.UserId, new List<string>());
            return _mapper.Map<List<ContractDto>>(allContracts);
        }
    }
}
