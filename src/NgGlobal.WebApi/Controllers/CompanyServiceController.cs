using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Extensions;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.WebApi.AuthorizeConstatnts;
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
        [ApiVersion("2.0")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllCompanyServicesQuery());
            return Ok(response);
        }

        [HttpGet("/api/CompanyService/Read")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllCompanyInfo()
        {
            var response = await _mediator.Send(new ReadAllCompanyServicesQuery());
            return Ok(response);
        }

        // GET api/<CompanyServiceController>/5
        [HttpGet("{id}")]
        [MapToApiVersion("2")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadCompanyServiceByIdQuery() { CompanyServiceId = id });
            return Ok(response);
        }

        /*[Authorize(Roles = UserType.Admin)]*/
        [HttpPost]
        [Authorize(Roles = UserType.Admin)]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Post([FromBody] CreateCompanyServiceCommand request)
        {
            request.ImageFile = request.ImageBaseUrl.Base64ToImage();
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Put([FromBody] UpdateCompanyServiceCommand request)
        {
            try
            {
                request.ImageFile = request.ImageBaseUrl.Base64ToImage();
            }
            catch (Exception ex) { }
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpDelete("{id}")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _mediator.Send(new DeleteCompanyServiceCommand() { DailyDatasetId = id });
            return Ok(response);
        }
    }
}
