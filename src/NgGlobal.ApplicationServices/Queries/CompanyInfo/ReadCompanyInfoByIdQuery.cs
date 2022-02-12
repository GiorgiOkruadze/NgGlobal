using MediatR;
using NgGlobal.ApplicationShared.DTOs;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadCompanyInfoByIdQuery: IRequest<CompanyInfoDto>
    {
        public int CompanyInfoId { get; set; }
    }
}
