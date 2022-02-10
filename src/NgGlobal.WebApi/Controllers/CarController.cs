using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.CoreServices.Repositories.Abstractions;
using NgGlobal.DatabaseModels.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NgGlobal.WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator = default;

        public CarController(IMediator mediator, IUserRepository _repo)
        {
            _mediator = mediator;
          
        }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllCarsQuery());
            return Ok(response);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCarCommand request)
        {
            if(request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response)
;        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCarCommand request)
        {
            if(request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response)
;        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
