using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Extensions;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.WebApi.AuthorizeConstatnts;
using System;
using System.Collections.Generic;
using System.IO;
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
            var response = await _mediator.Send(new ReadDailyDatasetByIdQuery() { DailyDatasetId = id });
            return Ok(response);
        }





        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDailyDatasetCommand request)
        {
           
            request.ImageFile = request.ImageBaseUrl.Base64ToImage();
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateDailyDatasetCommand request)
        {
            request.Image = request.ImageBaseUrl.Base64ToImage();
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteDailyDatasetCommand() { DailyDatasetId = id });
            return Ok(response);
        }
    }
}
