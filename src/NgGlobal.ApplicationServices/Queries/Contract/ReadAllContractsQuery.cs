using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadAllContractsQuery : IRequest<List<ContractDto>> { }
}
