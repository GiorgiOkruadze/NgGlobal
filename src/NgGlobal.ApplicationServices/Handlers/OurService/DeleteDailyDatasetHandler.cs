using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Services.Abstractions;
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
    public class DeleteCompanyServiceHandler : IRequestHandler<DeleteCompanyServiceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ITranslationService _translationService = default;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;

        public DeleteCompanyServiceHandler(IMapper mapper, ITranslationService translationService, IRepository<CompanyService> companyServiceRepository)
        {
            _mapper = mapper;
            _translationService = translationService;
            _companyServiceRepository = companyServiceRepository;
        }

        public async Task<bool> Handle(DeleteCompanyServiceCommand request, CancellationToken cancellationToken)
        {
            var companyService = await _companyServiceRepository.GetOneAsync(o => o.Id == request.DailyDatasetId, new List<string>()
                {
                    "TitleTranslations",
                    "ShortDescriptionTranslations",
                    "LongDescriptionTranslations",
                    "Image"
                });

            var listTranslationids = companyService.TitleTranslations.Select(o => o.Id).ToList();
            listTranslationids.AddRange(companyService.ShortDescriptionTranslations.Select(o => o.Id));
            listTranslationids.AddRange(companyService.LongDescriptionTranslations.Select(o => o.Id));

            await _translationService.DeleteTranslationsAsync(listTranslationids);
            return await _companyServiceRepository.DeleteAsync(request.DailyDatasetId);
        }
    }
}
