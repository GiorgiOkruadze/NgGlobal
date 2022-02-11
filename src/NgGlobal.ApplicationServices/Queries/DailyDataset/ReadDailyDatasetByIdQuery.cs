using MediatR;
using NgGlobal.ApplicationShared.DTOs;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadDailyDatasetByIdQuery : IRequest<DailyDatasetDto> 
    { 
        public int DailyDatasetId { get; set; }
    }
}
