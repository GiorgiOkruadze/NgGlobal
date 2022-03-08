using MediatR;
using NgGlobal.ApplicationShared.DTOs;

namespace NgGlobal.ApplicationServices.Queries
{
    public class GetCompanyInfoQuery:IRequest<CompanyInfoDto>
    {
    }
}
