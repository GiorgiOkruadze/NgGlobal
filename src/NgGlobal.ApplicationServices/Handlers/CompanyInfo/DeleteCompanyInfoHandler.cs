using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class DeleteCompanyInfoHandler : IRequestHandler<DeleteCompanyInfoCommand, bool>
    {
        private readonly IRepository<CompanyInfo> _companyInfoRepository = default;

        public DeleteCompanyInfoHandler(IRepository<CompanyInfo> companyInfoRepository)
        {
            _companyInfoRepository = companyInfoRepository;
        }

        public async Task<bool> Handle(DeleteCompanyInfoCommand request, CancellationToken cancellationToken)
        {
            return await _companyInfoRepository.DeleteAsync(request.CompanyInfoId);
        }
    }
}
