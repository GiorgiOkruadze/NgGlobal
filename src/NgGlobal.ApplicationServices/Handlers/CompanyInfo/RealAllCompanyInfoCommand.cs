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
    public class RealAllCompanyInfoCommand : IRequestHandler<RealAllCompanyInfoQuery, List<CompanyInfoDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyInfo> _companyInfoRepository = default;

        public RealAllCompanyInfoCommand(IMapper mapper, IRepository<CompanyInfo> companyInfoRepository)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<List<CompanyInfoDto>> Handle(RealAllCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            var companyInfo = await _companyInfoRepository
                .GetAllAsync(new List<string>() { "AddressTranslations", "AddressTranslations.Language" });

            return _mapper.Map<List<CompanyInfoDto>>(companyInfo);
        }
    }
}
