using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.FileStorageService;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class CreateImageForCarHandler : IRequestHandler<CreateImageForCarCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Image> _imageRepository;
        private readonly IMediaService _mediaService;


        public CreateImageForCarHandler(IRepository<Image> imageRepository, IMapper mapper, IMediaService mediaService)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            _mediaService = mediaService;
        }

        public async Task<bool> Handle(CreateImageForCarCommand request, CancellationToken cancellationToken)
        {
            var cloudResult = await _mediaService.UploadImage(request.Image);

            var image = new Image()
            {
                CarId = request.CarId,
                ImageName = cloudResult.Url.AbsoluteUri,
                PublicId = cloudResult.PublicId
            };
            return await _imageRepository.CreateAsync(image);
        }
    }
}
