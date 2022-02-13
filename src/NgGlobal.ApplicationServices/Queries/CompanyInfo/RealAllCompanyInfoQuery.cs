using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Queries
{
    public class RealAllCompanyInfoQuery:IRequest<List<CompanyInfoDto>>
    {
    }
}
