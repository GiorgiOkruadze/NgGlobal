﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Queries;
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
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllCarsQuery());
            return Ok(response);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadCarByIdQuery() { CarId = id});
            return Ok(response);
        }

        // POST api/<CarController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCarCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT api/<CarController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCarCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response)
;
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCarCommand() { CarId = id });
            return Ok(response);
        }

        [HttpPost(nameof(UploadCarImage))]
        public async Task<IActionResult> UploadCarImage([FromForm] CreateImageForCarCommand command)
        {
            var result =await _mediator.Send(command);

            return Ok(result);
        }

    }
}
