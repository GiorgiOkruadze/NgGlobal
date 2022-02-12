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
    public class UpdateCompanyInfoHandler : IRequestHandler<UpdateCompanyInfoCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyInfo> _companyInfoRepository = default;

        public UpdateCompanyInfoHandler(IMapper mapper, IRepository<CompanyInfo> companyInfoRepository)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<bool> Handle(UpdateCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            var companyInfo = _mapper.Map<CompanyInfo>(request);
            return await _companyInfoRepository.UpdateAsync(request.Id,companyInfo);
        }
    }
}
