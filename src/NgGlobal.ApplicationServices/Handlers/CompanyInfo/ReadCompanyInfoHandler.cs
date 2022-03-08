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
    public class ReadCompanyInfoHandler : IRequestHandler<GetCompanyInfoQuery, CompanyInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyInfo> _companyInfoRepository = default;

        public ReadCompanyInfoHandler(IMapper mapper, IRepository<CompanyInfo> companyInfoRepository)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<CompanyInfoDto> Handle(GetCompanyInfoQuery request, CancellationToken cancellationToken)
        {
            var companyInfo = (await _companyInfoRepository
                .GetAllAsync(new List<string>() { "AddressTranslations", "AddressTranslations.Language" })).FirstOrDefault();

            return _mapper.Map<CompanyInfoDto>(companyInfo);
        }
    }
}
