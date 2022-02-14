
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
    public class UpdateCompanyServiceHandler : IRequestHandler<UpdateCompanyServiceCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CompanyService> _companyServiceRepository = default;
        private readonly IMediaService _mediaService;

        public UpdateCompanyServiceHandler(IMapper mapper, IRepository<CompanyService> companyServiceRepository, IMediaService mediaService)
        {
            _mapper = mapper;
            _companyServiceRepository = companyServiceRepository;
            _mediaService = mediaService;
        }

        public async Task<bool> Handle(UpdateCompanyServiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediaService.UploadImage(request.Image);

                var mappedDailyDataset = _mapper.Map<CompanyService>(request);
                mappedDailyDataset.Image = new CompanyServiceImage()
                {
                    ImageUrl = result.Url.AbsoluteUri.Split("/").LastOrDefault(),
                    PublicId = result.PublicId
                };
                var response = await _companyServiceRepository.UpdateAsync(mappedDailyDataset.Id, mappedDailyDataset);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
