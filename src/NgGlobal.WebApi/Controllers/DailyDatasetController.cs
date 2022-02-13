using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NgGlobal.WebApi.Controllers
{
    public class DailyDatasetController : BaseController
    {
        public DailyDatasetController(IMediator mediator) : base(mediator) { }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllDailyDatasetQuery());
            return Ok(response);
        }

        // GET api/<CompanyServiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadDailyDatasetByIdQuery(){ DailyDatasetId = id});
            return Ok(response);
        }

        // POST api/<CompanyServiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDailyDatasetCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT api/<CompanyServiceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateDailyDatasetCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // DELETE api/<CompanyServiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteDailyDatasetCommand() { DailyDatasetId = id });
            return Ok(response);
        }
    }
}
