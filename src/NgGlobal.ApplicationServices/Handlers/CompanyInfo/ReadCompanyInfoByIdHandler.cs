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
    public class ReadCompanyInfoByIdHandler : IRequestHandler<ReadCompanyInfoByIdQuery, CompanyInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyInfo> _companyInfoRepository = default;

        public ReadCompanyInfoByIdHandler(IMapper mapper, IRepository<CompanyInfo> companyInfoRepository)
        {
            _mapper = mapper;
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<CompanyInfoDto> Handle(ReadCompanyInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var companyInfo = await _companyInfoRepository
                .GetOneAsync(o => o.Id == request.CompanyInfoId, new List<string>() { "AddressTranslations", "AddressTranslations.Language" });

            return _mapper.Map<CompanyInfoDto>(companyInfo);
        }
    }
}
