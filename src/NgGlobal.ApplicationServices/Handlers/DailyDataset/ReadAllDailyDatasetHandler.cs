using AutoMapper;
using MediatR;
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
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;

        public ReadAllDailyDatasetHandler(IMapper mapper, IRepository<DailyDataset> dailyDatasetRepository)
        {
            _mapper = mapper;
            _dailyDatasetRepository = dailyDatasetRepository;
        }

        public async Task<List<DailyDatasetDto>> Handle(ReadAllDailyDatasetQuery request, CancellationToken cancellationToken)
        {
            var dailyDatasets = await _dailyDatasetRepository.GetAllAsync(new List<string>()
            {
                "TitleTranslations",
                "TitleTranslations.Language",
                "ShortDescriptionTranslations",
                "ShortDescriptionTranslations.Language",
                "LongDescriptionTranslations",
                "LongDescriptionTranslations.Language",
            });
            var mappedDailyDatasets = _mapper.Map<List<DailyDatasetDto>>(dailyDatasets);
            return mappedDailyDatasets;
        }
    }
}
