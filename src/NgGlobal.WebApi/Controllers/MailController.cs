using MediatR;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.WebApi.Controllers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NgGlobal.WebApp.ApiControllers
{
   
    public class MailController : BaseController
    {
        public MailController(IMediator mediator) : base(mediator) { }

        // POST api/<CarController>
        [HttpPost("/api/mail/sent")]
        [ApiVersion("2.0")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> SentMail([FromBody] SentMailCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("/api/mail/sentCarInfo")]
        [ApiVersion("2.0")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> SentCarMail([FromBody] SetMailAboutCarCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
