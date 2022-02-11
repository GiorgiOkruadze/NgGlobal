using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.FileStorageService;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    class DeleteImageForCarCommandHandler : IRequestHandler<DeleteImageFromCarCommand, bool>
    {
        private readonly IRepository<Image> _imageRepository;
        private readonly IMediaService _mediaService;

        public DeleteImageForCarCommandHandler(IRepository<Image> imageRepository, IMediaService mediaService)
        {
            _imageRepository = imageRepository;
            _mediaService = mediaService;
        }
        public async Task<bool> Handle(DeleteImageFromCarCommand request, CancellationToken cancellationToken)
        {
            var currentImage = await _imageRepository.GetOneAsync(i => i.Id == request.ImageId, new System.Collections.Generic.List<System.Linq.Expressions.Expression<System.Func<Image, object>>>());

            await _mediaService.DeleteImage(currentImage.PublicId);

            return await _imageRepository.DeleteAsync(request.ImageId);
        }
    }
}
