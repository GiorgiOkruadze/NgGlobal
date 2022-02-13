using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices
{
    public class UpdateContractHandler : IRequestHandler<UpdateContractCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Contract> _contractRepository;

        public UpdateContractHandler(IRepository<Contract> contractRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
        }

        public async Task<bool> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var contract = _mapper.Map<Contract>(request);
            return await _contractRepository.UpdateAsync(request.Id, contract);
        }
    }
}
