using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var results = (await _imageRepository.GetAsync(i => i.CarId == request.CarId,new List<Expression<Func<Image, object>>>())).ToList();
            results.ForEach(image =>
            {
                if (image.Id == request.ImageId)
                    image.IsMainImage = true;
                else
                    image.IsMainImage = false;
            });
            return await _imageRepository.SaveAsync();
        }
    }
}
