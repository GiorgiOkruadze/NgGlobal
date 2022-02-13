using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Extensions;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class FilterCarsHandler:IRequestHandler<FilterCarsQuery,List<CarDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Car> _carRepository = default;

        public FilterCarsHandler(IMapper mapper, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<List<CarDto>> Handle(FilterCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllAsync(new List<string>()
            {
                "DriveTrainTranslations",
                "DriveTrainTranslations.Language",
                "FuelTypeTranslations",
                "FuelTypeTranslations.Language",
                "TransmissionTranslations",
                "TransmissionTranslations.Language",
                "Images"
            });

            var filteredCars = cars
                ?.WhereIf(!string.IsNullOrEmpty(request.Manufacture),o => o.Manufacture == request.Manufacture)
                ?.WhereIf(!string.IsNullOrEmpty(request.Model), o => o.Model == request.Model)
                ?.Where(o => DateTime.Compare(request.YearFrom, o.Year) >= 0 && DateTime.Compare(o.Year,request.YearTo) >= 0)
                ?.WhereIf(request.MileFrom!=null, o=> o.Mile>=request.MileFrom)
                ?.WhereIf(request.MileTo != null, o => o.Mile >= request.MileTo)
                ?.WhereIf(!string.IsNullOrEmpty(request.FuelType), o => o.FuelTypeTranslations?.FirstOrDefault(fuel => fuel.LanguageId==1).Text.ToLower() == request.FuelType.ToLower())
                ?.WhereIf(request.PriceFrom != null, o => o.Mile >= request.PriceFrom)
                ?.WhereIf(request.PriceTo != null, o => o.Mile >= request.PriceTo)
                ?.ToList();

            var mappedCars = _mapper.Map<List<CarDto>>(cars);
            return mappedCars;
        }
    }
}
