using AutoMapper;
using MediatR;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NgGlobal.ApplicationServices.Handlers
{
    public class DeleteDailyDatasetHandler : IRequestHandler<DeleteDailyDatasetCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DailyDataset> _dailyDatasetRepository = default;

        public DeleteDailyDatasetHandler(IMapper mapper, IRepository<DailyDataset> dailyDatasetRepository)
        {
            _mapper = mapper;
            _dailyDatasetRepository = dailyDatasetRepository;
        }

        public async Task<bool> Handle(DeleteDailyDatasetCommand request, CancellationToken cancellationToken)
        {
            return await _dailyDatasetRepository.DeleteAsync(request.DailyDatasetId);
        }
    }
}
