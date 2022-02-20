using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Services.Abstractions;
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
    public class DeleteDailyDatasetHandler : IRequestHandler<DeleteDailyDatasetCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;
        private readonly ITranslationService _translationService = default;


        public DeleteDailyDatasetHandler(IMapper mapper, ITranslationService translationService, IRepository<DailyDataset> dailyDatasetRepository)
        {
            _mapper = mapper;
            _dailyDatasetRepository = dailyDatasetRepository;
            _translationService = translationService;
        }

        public async Task<bool> Handle(DeleteDailyDatasetCommand request, CancellationToken cancellationToken)
        {
            var dailyDataset = await _dailyDatasetRepository.GetOneAsync(o => o.Id == request.DailyDatasetId, new List<string>()
                {
                    "TitleTranslations",
                    "ShortDescriptionTranslations",
                    "LongDescriptionTranslations",
                    "Image"
                });

            var listTranslationids = dailyDataset.TitleTranslations.Select(o => o.Id).ToList();
            listTranslationids.AddRange(dailyDataset.ShortDescriptionTranslations.Select(o => o.Id));
            listTranslationids.AddRange(dailyDataset.LongDescriptionTranslations.Select(o => o.Id));

            await _translationService.DeleteTranslationsAsync(listTranslationids);
            return await _dailyDatasetRepository.DeleteAsync(request.DailyDatasetId);
        }
    }
}
