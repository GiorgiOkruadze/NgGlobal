using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ImageSetAsMainCommandHandler : IRequestHandler<ImageSetAsMainCommand, bool>
    {
        private readonly IRepository<Image> _imageRepository;
        public ImageSetAsMainCommandHandler(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<bool> Handle(ImageSetAsMainCommand request, CancellationToken cancellationToken)
        {
             var result = await _imageRepository.GetOneAsync(i => i.Id == request.ImageId,new List<Expression<Func<Image, object>>>());
            result.IsMainImage = true;
            return await _imageRepository.SaveAsync();
        }
    }
}
