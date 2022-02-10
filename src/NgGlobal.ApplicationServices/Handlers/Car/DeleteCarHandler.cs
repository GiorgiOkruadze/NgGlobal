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
    public class DeleteCarHandler : IRequestHandler<DeleteCarCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Car> _carRepository = default;

        public DeleteCarHandler(IMapper mapper, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            return await _carRepository.DeleteAsync(request.CarId);
        }
    }
}
