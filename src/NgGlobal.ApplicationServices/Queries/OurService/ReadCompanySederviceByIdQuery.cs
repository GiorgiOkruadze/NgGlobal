using MediatR;
using NgGlobal.ApplicationShared.DTOs;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadCompanySederviceByIdQuery : IRequest<CompanyServiceDto> 
    { 
        public int DailyDatasetId { get; set; }
    }
}
