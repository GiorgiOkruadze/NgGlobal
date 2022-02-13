using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadAllImagesHandler:IRequestHandler<ReadAllImagesQuery,List<ImageDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Image> _imageRepository;

        public ReadAllImagesHandler(IRepository<Image> imageRepository, IMapper mapper)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task<List<ImageDto>> Handle(ReadAllImagesQuery request, CancellationToken cancellationToken)
        {
            var allImages = await _imageRepository.GetAllAsync(new List<string>());

            return _mapper.Map<List<ImageDto>>(allImages);
        }
    }
}
