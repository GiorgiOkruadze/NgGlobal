using AutoMapper;
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
    internal class ReadAllDailyDatasetHandler : IRequestHandler<ReadAllDailyDatasetQuery, List<DailyDatasetDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<ImageOption> _imageOption = default;
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;

        public ReadAllDailyDatasetHandler(IMapper mapper, IOptions<ImageOption> imageOption, IRepository<DailyDataset> dailyDatasetRepository)
        {
            _mapper = mapper;
            _imageOption = imageOption;
            _dailyDatasetRepository = dailyDatasetRepository;
        }

        public async Task<List<DailyDatasetDto>> Handle(ReadAllDailyDatasetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dailyDatasets = await _dailyDatasetRepository.GetAllAsync(new List<string>()
            {
                "TitleTranslations",
                "TitleTranslations.Language",
                "ShortDescriptionTranslations",
                "ShortDescriptionTranslations.Language",
                "LongDescriptionTranslations",
                "LongDescriptionTranslations.Language",
                "Image"
            });
                var mappedDailyDatasets = _mapper.Map<List<DailyDatasetDto>>(dailyDatasets);
                mappedDailyDatasets.ForEach(item =>
                {
                    item.ImageName = _imageOption.Value.Url + item.Image.ImageUrl;
                });

                return mappedDailyDatasets;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
