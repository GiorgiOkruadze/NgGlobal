using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Options;
using NgGlobal.ApplicationServices.ConfigurationOptions;
using NgGlobal.ApplicationServices.Paging;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationShared.DTOs;
using NgGlobal.ApplicationShared.Paging;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class ReadCarsByPagesHandler : IRequestHandler<ReadCarsByPagesQuery, PagingOutput<CarDto>>
    {
        private readonly IMapper _mapper;
        private readonly IOptions<ImageOption> _imageOption = default;
        private readonly IRepository<Car> _carRepository = default;

        public ReadCarsByPagesHandler(IMapper mapper, IOptions<ImageOption> imageOption, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _imageOption = imageOption;
            _carRepository = carRepository;
        }

        public async Task<PagingOutput<CarDto>> Handle(ReadCarsByPagesQuery request, CancellationToken cancellationToken)
        {
            var model = _carRepository.ReadPagedData(_mapper.Map<PagingParams>(request));
            var outputModel = new PagingOutput<CarDto>
            {
                Paging = model.GetHeader(),
                Items = model.List.Select(m => _mapper.Map<CarDto>(m)).ToList(),
            };
            outputModel.Items.ForEach(carItem =>
            {
                carItem.Images.ForEach(image =>
                {
                    image.ImageName = _imageOption.Value.Url + image.ImageName;
                });
            });
            return outputModel;
        }
    }
}
