
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
    public class CreateCompanyServiceHandler : IRequestHandler<CreateCompanyServiceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public CreateCompanyServiceHandler(IMapper mapper, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
        }

        public async Task<bool> Handle(CreateCompanyServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedDailyDataset = _mapper.Map<CompanyService>(request);
                var response = await _companyServiceRepository.CreateAsync(mappedDailyDataset);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
