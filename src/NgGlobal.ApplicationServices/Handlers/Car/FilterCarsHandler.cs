using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using NgGlobal.ApplicationServices.ConfigurationOptions;
using NgGlobal.ApplicationServices.Extensions;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.ApplicationShared.Paging;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class FilterCarsHandler:IRequestHandler<FilterCarsQuery, PagingOutput<CarDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<ImageOption> _imageOption = default;
        private readonly IRepository<Car> _carRepository = default;

        public FilterCarsHandler(IMapper mapper, IRepository<Car> carRepository, IOptions<ImageOption> imageOption)
        {
            _mapper = mapper;
            _imageOption = imageOption;
            _carRepository = carRepository;
        }

        public async Task<PagingOutput<CarDto>> Handle(FilterCarsQuery request, CancellationToken cancellationToken)
        { 
            var query = _carRepository.GetAsQuerable(new List<string>()
            {
                "DriveTrainTranslations",
                "DriveTrainTranslations.Language",
                "FuelTypeTranslations",
                "FuelTypeTranslations.Language",
                "TransmissionTranslations",
                "TransmissionTranslations.Language",
                "Images"
            })
                ?.WhereIf(!string.IsNullOrEmpty(request.Manufacture), o => o.Manufacturer == request.Manufacture)
                ?.WhereIf(!string.IsNullOrEmpty(request.Model), o => o.Model == request.Model)
                ?.WhereIf(request.YearFrom != null, o =>request.YearFrom  <= o.Year.Year)
                ?.WhereIf(request.YearTo != null, o => request.YearTo >= o.Year.Year)
                ?.WhereIf(request.MileFrom != null, o => o.Mile >= request.MileFrom)
                ?.WhereIf(request.MileTo != null, o => o.Mile >= request.MileTo)
                ?.WhereIf(!string.IsNullOrEmpty(request.FuelType), o => o.FuelTypeTranslations?.FirstOrDefault(fuel => fuel.LanguageId == 1).Text.ToLower() == request.FuelType.ToLower())
                ?.WhereIf(request.PriceFrom != null, o => o.Mile >= request.PriceFrom)
                ?.WhereIf(request.PriceTo != null, o => o.Mile >= request.PriceTo).AsQueryable();

            var pagesData = new PagedList<Car>(query, request.PageNumber, request.PageSize);

            var outputModel = new PagingOutput<CarDto>
            {
                Paging = pagesData.GetHeader(),
                Items = pagesData.List.Select(m => _mapper.Map<CarDto>(m)).ToList(),
            };

            outputModel.Items.ForEach(carItem =>
            {
                carItem.Images.ForEach(image =>
                {
                    image.ImageName = _imageOption.Value.Url + image.ImageName;
                });
            });

            return outputModel;
        }
    }
}
