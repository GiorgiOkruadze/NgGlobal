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
    public class DeleteCompanyServiceHandler : IRequestHandler<DeleteCompanyServiceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public DeleteCompanyServiceHandler(IMapper mapper, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
        }

        public async Task<bool> Handle(DeleteCompanyServiceCommand request, CancellationToken cancellationToken)
        {
            return await _companyServiceRepository.DeleteAsync(request.DailyDatasetId);
        }
    }
}
