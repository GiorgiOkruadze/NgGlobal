using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.ApplicationShared.Paging;
using System;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Queries
{
    public class FilterCarsQuery:IRequest<PagingOutput<CarDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;

        public string Manufacture { get; set; }
        public string Model { get; set; }
        public int? YearFrom { get; set; }
        public int? YearTo { get; set; }
        public double? MileFrom { get; set; }
        public double? MileTo { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
    }
}
