using Newtonsoft.Json;
using NgGlobal.ApplicationServices.Services.Abstractions;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Services
{
    public class FilterService : IFilterService
    {
        private readonly IFileService _fileService = default;
        private readonly IRepository<Car> _carRepository = default;

        public FilterService(IFileService fileService, IRepository<Car> carRepository)
        {
            _fileService = fileService;
            _carRepository = carRepository;
        }

        public async Task<FilterDto> ReadFilterAsync()
        {
            var fileData = await _fileService.GetDataFromFile("filters.json");
            return JsonConvert.DeserializeObject<FilterDto>(fileData);
        }

        public async Task<bool> WriteFilterInFileAsync()
        {
            try
            {
                var cars = (await _carRepository.GetAllAsync(new List<string>()
            {
                "DriveTrainTranslations",
                "DriveTrainTranslations.Language",
                "TransmissionTranslations",
                "TransmissionTranslations.Language",
            })).ToList();

                Task.Run(() =>
                {
                    var filter = new FilterDto()
                    {
                        MarksModels = cars.GroupBy(o => o.Manufacturer).ToDictionary(o => o.Key, o => o.Select(x => x.Model).ToList()),
                    YearFrom = cars.Min(o => o.Year).Year,
                        YearTo = cars.Max(o => o.Year).Year,
                        Transmissions = cars.SelectMany(o => o.TransmissionTranslations.Where(o => o.LanguageId == 1).Select(t => t.Text)).Distinct().ToList(),
                        PriceFrom = cars.Min(o => o.Price),
                        PriceTo = cars.Max(o => o.Price),
                        MileageFrom = cars.Min(o => o.Mile),
                        MileageTo = cars.Max(o => o.Mile),
                    };

                    var data = JsonConvert.SerializeObject(filter);
                    _fileService.WriteDataInFile("filters.json", data).Wait();
                    return true;
                });
            }catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
