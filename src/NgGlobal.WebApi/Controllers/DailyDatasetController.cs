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
        [ApiVersion("2.0")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllDailyDatasetQuery());
            return Ok(response);
        }

        [HttpGet("/api/DailyDataset/Read")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAllDailyDataset()
        {
            var response = await _mediator.Send(new ReadAllDailyDatasetQuery());
            return Ok(response);
        }

        // GET api/<CompanyServiceController>/5
        [HttpGet("{id}")]
        [MapToApiVersion("2")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadDailyDatasetByIdQuery() { DailyDatasetId = id });
            return Ok(response);
        }


        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Post([FromBody] CreateDailyDatasetCommand request)
        {
           
            request.ImageFile = request.ImageBaseUrl.Base64ToImage();
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Put([FromBody] UpdateDailyDatasetCommand request)
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
            var response = await _mediator.Send(new DeleteDailyDatasetCommand() { DailyDatasetId = id });
            return Ok(response);
        }
    }
}
