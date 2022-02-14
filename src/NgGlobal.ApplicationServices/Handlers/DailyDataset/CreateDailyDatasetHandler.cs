
using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.FileStorageService;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class CreateDailyDatasetHandler : IRequestHandler<CreateDailyDatasetCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;
        private readonly IMediaService _mediaService;
        public CreateDailyDatasetHandler(IMapper mapper, IRepository<DailyDataset> dailyDatasetRepository, IMediaService mediaService)
        {
            _mapper = mapper;
            _dailyDatasetRepository = dailyDatasetRepository;
            _mediaService = mediaService;
        }

        public async Task<bool> Handle(CreateDailyDatasetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cloudResult = await _mediaService.UploadImage(request.ImageFile);
                var mappedDailyDataset = _mapper.Map<DailyDataset>(request);
                mappedDailyDataset.Image = new DailyDatasetImage()
                {
                    ImageUrl = cloudResult.Url.AbsoluteUri.Split("/").LastOrDefault(),
                    PublicId = cloudResult.PublicId
                };

                var response = await _dailyDatasetRepository.CreateAsync(mappedDailyDataset);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
