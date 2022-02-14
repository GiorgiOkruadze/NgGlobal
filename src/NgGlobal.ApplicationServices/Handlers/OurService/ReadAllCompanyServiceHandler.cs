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
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    internal class ReadAllCompanyServiceHandler : IRequestHandler<ReadAllCompanyServicesQuery, List<CompanyServiceDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<ImageOption> _imageOption = default;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public ReadAllCompanyServiceHandler(IMapper mapper, IOptions<ImageOption> imageOption, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _imageOption = imageOption;
            _companyServiceRepository = companyServiceRepository;
        }

        public async Task<List<CompanyServiceDto>> Handle(ReadAllCompanyServicesQuery request, CancellationToken cancellationToken)
        {
            try
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
                    item.ImageName = _imageOption.Value.Url + item.Image.ImageUrl;
                });
                return mappedCompanyServices;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
