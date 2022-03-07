using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadContractsByUserIdQuery : IRequest<List<ContractDto>>
    {
        public int UserId { get; set; }
    }
}
