using MediatR;
using NgGlobal.ApplicationShared.DTOs;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadContractByUserIdQuery : IRequest<ContractDto>
    {
        public int UserId { get; set; }
    }
}
