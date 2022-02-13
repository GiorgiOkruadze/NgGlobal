using MediatR;

namespace NgGlobal.ApplicationServices.Commands
{
    public class DeleteCompanyInfoCommand:IRequest<bool>
    {
        public int CompanyInfoId { get; set; }
    }
}
