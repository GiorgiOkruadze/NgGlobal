using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadAllCarsHandler : IRequestHandler<ReadAllCarsQuery, IEnumerable<CarDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Car> _carRepository = default;

        public ReadAllCarsHandler(IMapper mapper, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarDto>> Handle(ReadAllCarsQuery request, CancellationToken cancellationToken)
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
            var mappedCars = _mapper.Map<List<CarDto>>(cars);
            return mappedCars;
        }
    }
}
