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
    internal class ReadAllCompanyServiceHandler : IRequestHandler<ReadAllCompanyServicesQuery, List<CompanyServiceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public ReadAllCompanyServiceHandler(IMapper mapper, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
        }

        public async Task<List<CompanyServiceDto>> Handle(ReadAllCompanyServicesQuery request, CancellationToken cancellationToken)
        {
            var companyServices = await _companyServiceRepository.GetAllAsync(new List<string>()
            {
                "TitleTranslations",
                "TitleTranslations.Language",
                "ShortDescriptionTranslations",
                "ShortDescriptionTranslations.Language",
                "LongDescriptionTranslations",
                "LongDescriptionTranslations.Language",
                "Image"
            });
            var mappedCompanyServices = _mapper.Map<List<CompanyServiceDto>>(companyServices);
            return mappedCompanyServices;
        }
    }
}
