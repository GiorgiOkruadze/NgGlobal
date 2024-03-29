﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using NgGlobal.ApplicationServices.ConfigurationOptions;
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
    internal class ReadCarByIdHandler : IRequestHandler<ReadCarByIdQuery, CarDto>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<ImageOption> _imageOption = default;
        private readonly IRepository<Car> _carRepository = default;

        public ReadCarByIdHandler(IMapper mapper, IOptions<ImageOption> imageOption, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _imageOption = imageOption;
            _carRepository = carRepository;
        }

        public async Task<CarDto> Handle(ReadCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetOneAsync(
                o => o.Id == request.CarId,
                new List<string>() 
                {
                    "DriveTrainTranslations",
                    "DriveTrainTranslations.Language",
                    "FuelTypeTranslations",
                    "FuelTypeTranslations.Language",
                    "TransmissionTranslations",
                    "TransmissionTranslations.Language",
                    "Images"
                });

            var mappedCar = _mapper.Map<CarDto>(car);
            mappedCar.Images.ForEach(image =>
            {
                image.ImageName = _imageOption.Value.Url + image.ImageName;
            });
            return mappedCar;
        }
    }
}
