using MediatR;
using NgGlobal.ApplicationShared.DTOs;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadContractByIdQuery:IRequest<ContractDto>
    {
        public int ContractId { get; set; }
    }
}
