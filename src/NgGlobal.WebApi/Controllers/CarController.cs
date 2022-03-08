using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.WebApi.AuthorizeConstatnts;
using NgGlobal.WebApi.Controllers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NgGlobal.WebApp.ApiControllers
{
   
    public class CarController : BaseController
    {
        public CarController(IMediator mediator) : base(mediator) { }

        // GET: api/<CarController>
        [HttpGet]
        [ApiVersion("2.0")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllCarsQuery());
            return Ok(response);
        }

        [HttpPost("/api/Car/Filter")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> FilterCars([FromBody]FilterCarsQuery request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("/api/Car/PageByPage")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> CarsPageByPage([FromBody] ReadCarsByPagesQuery request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination",response.Paging.ToJson());
            return Ok(response);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        [MapToApiVersion("2")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadCarByIdQuery() { CarId = id});
            return Ok(response);
        }

        [HttpGet("/api/Car/ByUser/{userId}")]
        [MapToApiVersion("2")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var response = await _mediator.Send(new ReadCarsByUserIdQuery() { UserId = userId });
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Post([FromBody] CreateCarCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Put([FromBody] UpdateCarCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response)
;
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpDelete("{id}")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCarCommand() { CarId = id });
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost(nameof(UploadCarImage))]
        [MapToApiVersion("2")]
        public async Task<IActionResult> UploadCarImage([FromForm] CreateImageForCarCommand command)
        {
            var result =await _mediator.Send(command);

            return Ok(result);
        }

    }
}
