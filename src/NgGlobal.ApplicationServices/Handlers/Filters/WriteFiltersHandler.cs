
using MediatR;
using Newtonsoft.Json;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Services.Abstractions;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers.Filters
{
    public class WriteFiltersHandler : IRequestHandler<WriteFiltersCommand, bool>
    {
        private readonly IFileService _fileService = default;
        private readonly IRepository<Car> _carRepository = default;

        public WriteFiltersHandler(IFileService fileService, IRepository<Car> carRepository)
        {
            _fileService = fileService;
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(WriteFiltersCommand request, CancellationToken cancellationToken)
        {
            var cars = (await _carRepository.GetAllAsync(new List<string>()
            {
                "DriveTrainTranslations",
                "DriveTrainTranslations.Language",
                "FuelTypeTranslations",
                "FuelTypeTranslations.Language",
                "TransmissionTranslations",
                "TransmissionTranslations.Language",
            })).ToList();

            var filter = new FilterDto()
            {
                Models = cars.Select(x => x.Model).Distinct().ToList(),
                Makes = cars.Select(x => x.Manufacturer).Distinct().ToList(),
                YearFrom = cars.Min(o => o.Year).Year,
                YearTo = cars.Max(o => o.Year).Year,
                Transmissions = cars.SelectMany(o => o.TransmissionTranslations.Where(o => o.LanguageId == 1).Select(t => t.Text)).Distinct().ToList(),
                PriceFrom = cars.Min(o => o.Price),
                PriceTo = cars.Max(o => o.Price),
                MileageFrom = cars.Min(o => o.Mile),
                MileageTo = cars.Max(o => o.Mile),
                FuelTypes = cars.SelectMany(o => o.FuelTypeTranslations.Where(o => o.LanguageId == 1).Select(t => t.Text)).Distinct().ToList(),
            };

            var data = JsonConvert.SerializeObject(filter);
            return await _fileService.WriteDataInFile("filters.json", data);
        }
    }
}
