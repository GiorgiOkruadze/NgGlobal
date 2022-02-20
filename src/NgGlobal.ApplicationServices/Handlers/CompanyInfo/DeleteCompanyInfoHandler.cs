using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Services.Abstractions;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class DeleteCompanyInfoHandler : IRequestHandler<DeleteCompanyInfoCommand, bool>
    {
        private readonly IRepository<CompanyInfo> _companyInfoRepository = default;
        private readonly ITranslationService _translationService = default;

        public DeleteCompanyInfoHandler(IRepository<CompanyInfo> companyInfoRepository,
            ITranslationService translationService)
        {
            _companyInfoRepository = companyInfoRepository;
            _translationService = translationService;
        }

        public async Task<bool> Handle(DeleteCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            var companyInfo = await _companyInfoRepository
                .GetOneAsync(o => o.Id == request.CompanyInfoId, new List<string>() { "AddressTranslations", "AddressTranslations.Language" });

            await _translationService.DeleteTranslationsAsync(companyInfo.AddressTranslations.Select(o => o.Id));
            return await _companyInfoRepository.DeleteAsync(request.CompanyInfoId);
        }
    }
}
