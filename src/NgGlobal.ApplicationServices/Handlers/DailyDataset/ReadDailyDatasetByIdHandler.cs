using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.ConfigurationOptions;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadDailyDatasetByIdHandler : IRequestHandler<ReadDailyDatasetByIdQuery, DailyDatasetDto>
    {
        private readonly IMapper _mapper;
        private readonly ImageOption _imageOption = default;
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;

        public ReadDailyDatasetByIdHandler(IMapper mapper, ImageOption imageOption, IRepository<DailyDataset> dailyDatasetRepository)
        {
            _mapper = mapper;
            _imageOption = imageOption;
            _dailyDatasetRepository = dailyDatasetRepository;
        }

        public async Task<DailyDatasetDto> Handle(ReadDailyDatasetByIdQuery request, CancellationToken cancellationToken)
        {
            var dailyDataset = await _dailyDatasetRepository.GetOneAsync(o => o.Id == request.DailyDatasetId,new List<string>()
            {
                "TitleTranslations",
                "TitleTranslations.Language",
                "ShortDescriptionTranslations",
                "ShortDescriptionTranslations.Language",
                "LongDescriptionTranslations",
                "LongDescriptionTranslations.Language",
                "Image"
            });
            var mappedDailyDataset = _mapper.Map<DailyDatasetDto>(dailyDataset);
            mappedDailyDataset.ImageName = _imageOption.Url + mappedDailyDataset.Image.ImageUrl;
            return mappedDailyDataset;
        }
    }
}
