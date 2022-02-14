using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.ConfigurationOptions;
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
        private readonly ImageOption _imageOption = default;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public ReadAllCompanyServiceHandler(IMapper mapper, ImageOption imageOption, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _imageOption = imageOption;
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
            mappedCompanyServices.ForEach(item =>
            {
                item.ImageName = _imageOption.Url + item.Image.ImageUrl;
            });
            return mappedCompanyServices;
        }
    }
}
