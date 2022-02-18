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
   
    public class ImageController : BaseController
    {
        public ImageController(IMediator mediator) : base(mediator) { }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllImagesQuery());
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost("/api/Image/SetAsMain")]
        public async Task<IActionResult> SetAsMainImage([FromBody] ImageSetAsMainCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost("/api/Image/Delete")]
        public async Task<IActionResult> DeleteImage([FromBody] DeleteImageFromCarCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
