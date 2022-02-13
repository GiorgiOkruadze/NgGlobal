using MediatR;
using NgGlobal.ApplicationShared.DTOs;
using System;
using System.Collections.Generic;

namespace NgGlobal.ApplicationServices.Queries
{
    public class FilterCarsQuery:IRequest<List<CarDto>>
    {
        public string Manufacture { get; set; }
        public string Model { get; set; }
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }
        public double? MileFrom { get; set; }
        public double? MileTo { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
    }
}
