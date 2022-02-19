using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
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
        private readonly IRepository<Translation> _translationRepository = default;

        public DeleteCarHandler(IMapper mapper, IRepository<Translation> translationRepository, IRepository<Car> carRepository)
        {
            _translationRepository = translationRepository;
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
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

            var translationids = car.DriveTrainTranslations.Select(o => o.Id).ToList();
            translationids.AddRange(car.FuelTypeTranslations.Select(o => o.Id));
            translationids.AddRange(car.TransmissionTranslations.Select(o => o.Id));
            await DeleteTranslationsAsync(translationids);
            return await _carRepository.DeleteAsync(request.CarId);
        }

        public async Task<bool> DeleteTranslationsAsync(List<int> ids)
        {
            foreach(var item in ids)
            {
                await _translationRepository.DeleteAsync(item);
            }

            return true;
        }
    }
}
