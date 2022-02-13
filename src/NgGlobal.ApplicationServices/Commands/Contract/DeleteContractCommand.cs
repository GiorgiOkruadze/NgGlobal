using MediatR;


namespace NgGlobal.ApplicationServices.Commands
{
    public class DeleteContractCommand:IRequest<bool>
    {
        public int ContractId { get; set; }
    }
}
