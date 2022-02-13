using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
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
    public class DeleteContractHandler : IRequestHandler<DeleteContractCommand, bool>
    {
        private readonly IRepository<Contract> _contractRepository;

        public DeleteContractHandler(IRepository<Contract> contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public async Task<bool> Handle(DeleteContractCommand request, CancellationToken cancellationToken)
        {
            return await _contractRepository.DeleteAsync(request.ContractId);
        }
    }
}
