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
    public class CreateCarHandler : IRequestHandler<CreateCarCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Car> _carRepository = default;

        public CreateCarHandler(IMapper mapper, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mappedCar = _mapper.Map<Car>(request);
                var response = await _carRepository.CreateAsync(mappedCar);
                return response;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
