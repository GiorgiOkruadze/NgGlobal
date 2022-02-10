using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    class DeleteImageForCarCommandHandler : IRequestHandler<DeleteImageFromCarCommand, bool>
    {
        private readonly IRepository<Image> _imageRepository;

        public DeleteImageForCarCommandHandler(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<bool> Handle(DeleteImageFromCarCommand request, CancellationToken cancellationToken)
        {
            return await _imageRepository.DeleteAsync(request.ImageId);
        }
    }
}
