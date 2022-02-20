using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Services.Abstractions;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class DeleteCarHandler : IRequestHandler<DeleteCarCommand,bool>
    {
        private readonly IRepository<Car> _carRepository = default;
        private readonly ITranslationService _translationService = default;

        public DeleteCarHandler(IMapper mapper, ITranslationService translationService, IRepository<Car> carRepository)
        {
            _translationService = translationService;
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetOneAsync(
                o => o.Id == request.CarId,
                new List<string>()
                {
                    "DriveTrainTranslations",
                    "FuelTypeTranslations",
                    "TransmissionTranslations",
                    "Images"
                });

            var translationids = car.DriveTrainTranslations.Select(o => o.Id).ToList();
            translationids.AddRange(car.FuelTypeTranslations.Select(o => o.Id));
            translationids.AddRange(car.TransmissionTranslations.Select(o => o.Id));
            await _translationService.DeleteTranslationsAsync(translationids);
            return await _carRepository.DeleteAsync(request.CarId);
        }
    }
}
