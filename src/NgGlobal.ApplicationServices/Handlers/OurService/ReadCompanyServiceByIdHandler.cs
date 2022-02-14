using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using NgGlobal.ApplicationServices.ConfigurationOptions;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadCompanyServiceByIdHandler : IRequestHandler<ReadCompanyServiceByIdQuery, CompanyServiceDto>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<ImageOption> _imageOption = default;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public ReadCompanyServiceByIdHandler(IMapper mapper, IOptions<ImageOption> imageOption, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _imageOption = imageOption;
            _companyServiceRepository = companyServiceRepository;
        }

        public async Task<CompanyServiceDto> Handle(ReadCompanyServiceByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var companyService = await _companyServiceRepository.GetOneAsync(o => o.Id == request.CompanyServiceId, new List<string>()
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
                mappedCompanyService.ImageName = _imageOption.Value.Url + mappedCompanyService.Image.ImageUrl;
                return mappedCompanyService;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
