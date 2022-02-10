using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class CreateImageForCarHandler: IRequestHandler<CreateImageForCarCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Image> _imageRepository;

        public CreateImageForCarHandler(IRepository<Image> imageRepository, IMapper mapper)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<bool> Handle(CreateImageForCarCommand request, CancellationToken cancellationToken)
        {
            var image = _mapper.Map<Image>(request);
            return await _imageRepository.CreateAsync(image);
        }
    }
}
