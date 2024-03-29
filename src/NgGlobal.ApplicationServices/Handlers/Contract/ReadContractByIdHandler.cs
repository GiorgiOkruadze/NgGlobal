﻿using AutoMapper;
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
    public class ReadContractByIdHandler:IRequestHandler<ReadContractByIdQuery,ContractDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Contract> _contractRepository;

        public ReadContractByIdHandler(IRepository<Contract> contractRepository, IMapper mapper)
        {
            _mapper = mapper;
            _contractRepository = contractRepository;
        }

        public async Task<ContractDto> Handle(ReadContractByIdQuery request, CancellationToken cancellationToken)
        {
            var allContracts = await _contractRepository.GetOneAsync(o => o.Id == request.ContractId, new List<string>());
            return _mapper.Map<ContractDto>(allContracts);
        }
    }
}
