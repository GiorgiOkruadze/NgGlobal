using AutoMapper;
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
    public class ReadCompanyServiceByIdHandler : IRequestHandler<ReadCompanyServiceByIdQuery, CompanyServiceDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public ReadCompanyServiceByIdHandler(IMapper mapper, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
        }

        public async Task<CompanyServiceDto> Handle(ReadCompanyServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var companyService = await _companyServiceRepository.GetOneAsync(o => o.Id == request.CompanyServiceId,new List<string>()
            {
                "TitleTranslations",
                "TitleTranslations.Language",
                "ShortDescriptionTranslations",
                "ShortDescriptionTranslations.Language",
                "LongDescriptionTranslations",
                "LongDescriptionTranslations.Language",
                "Image"
            });
            var mappedCompanyService = _mapper.Map<CompanyServiceDto>(companyService);
            return mappedCompanyService;
        }
    }
}
