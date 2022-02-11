
using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class CreateDailyDatasetHandler : IRequestHandler<CreateDailyDatasetCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;

        public CreateDailyDatasetHandler(IMapper mapper, IRepository<DailyDataset> dailyDatasetRepository)
        {
            _mapper = mapper;
            _dailyDatasetRepository = dailyDatasetRepository;
        }

        public async Task<bool> Handle(CreateDailyDatasetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedDailyDataset = _mapper.Map<DailyDataset>(request);
                var response = await _dailyDatasetRepository.CreateAsync(mappedDailyDataset);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
