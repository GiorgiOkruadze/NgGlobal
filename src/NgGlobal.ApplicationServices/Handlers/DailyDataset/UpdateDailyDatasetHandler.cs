
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
    public class UpdateDailyDatasetHandler : IRequestHandler<UpdateDailyDatasetCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;
        private readonly IMediaService _mediaService;

        public UpdateDailyDatasetHandler(IMapper mapper, IRepository<DailyDataset> dailyDatasetRepository, IMediaService mediaService)
        {
            _mapper = mapper;
            _dailyDatasetRepository = dailyDatasetRepository;
            _mediaService = mediaService;
        }

        public async Task<bool> Handle(UpdateDailyDatasetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediaService.UploadImage(request.Image);

                var mappedDailyDataset = _mapper.Map<DailyDataset>(request);
                mappedDailyDataset.Image = new DailyDatasetImage()
                {
                    ImageUrl = result.Url.AbsoluteUri.Split("/").LastOrDefault(),
                    PublicId = result.PublicId
                };
                var response = await _dailyDatasetRepository.UpdateAsync(mappedDailyDataset.Id, mappedDailyDataset);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
