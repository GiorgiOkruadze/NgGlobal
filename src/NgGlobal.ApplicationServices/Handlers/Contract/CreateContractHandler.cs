using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class CreateContractHandler : IRequestHandler<CreateContractCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Contract> _contractRepository;

        public CreateContractHandler(IRepository<Contract> contractRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
        }

        public async Task<bool> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = _mapper.Map<Contract>(request);
            return await _contractRepository.CreateAsync(contract);
        }
    }
}
