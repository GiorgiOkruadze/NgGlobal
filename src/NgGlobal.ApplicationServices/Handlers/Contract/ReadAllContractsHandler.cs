using AutoMapper;
using MediatR;
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
    internal class ReadAllContractsHandler : IRequestHandler<ReadAllContractsQuery, List<ContractDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Contract> _contractRepository;

        public ReadAllContractsHandler(IRepository<Contract> contractRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
        }

        public async Task<List<ContractDto>> Handle(ReadAllContractsQuery request, CancellationToken cancellationToken)
        {
            var allContracts = await _contractRepository.GetAllAsync(new List<string>());
            return _mapper.Map<List<ContractDto>>(allContracts);    
        }
    }
}
