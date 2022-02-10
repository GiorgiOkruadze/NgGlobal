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
    public class UpdateCarHandler : IRequestHandler<UpdateCarCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Car> _carRepository = default;

        public UpdateCarHandler(IMapper mapper, IRepository<Car> carRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }

        public async Task<bool> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = _mapper.Map<Car>(request);
            return await _carRepository.UpdateAsync(request.CarId, car);
        }
    }
}
