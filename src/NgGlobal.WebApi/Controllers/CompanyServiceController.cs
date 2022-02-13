using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Extensions;
using NgGlobal.ApplicationServices.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NgGlobal.WebApi.Controllers
{

    public class CompanyServiceController : BaseController
    {
        public CompanyServiceController(IMediator mediator) : base(mediator) { }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllCompanyServicesQuery());
            return Ok(response);
        }

        // GET api/<CompanyServiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadCompanyServiceByIdQuery() { CompanyServiceId = id });
            return Ok(response);
        }

        // POST api/<CompanyServiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCompanyServiceCommand request)
        {
            request.ImageFile = request.ImageName.Base64ToImage();
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // PUT api/<CompanyServiceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCompanyServiceCommand request)
        {
            request.Image = request.ImageName.Base64ToImage();
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // DELETE api/<CompanyServiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _mediator.Send(new DeleteCompanyServiceCommand() { DailyDatasetId = id });
            return Ok(response);
        }
    }
}
