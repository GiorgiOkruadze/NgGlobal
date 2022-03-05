using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.ApplicationShared.Paging;

namespace NgGlobal.ApplicationServices.Queries
{
    public class ReadCarsByPagesQuery:IRequest<PagingOutput<CarDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
