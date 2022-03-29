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
   
    public class FilterController : BaseController
    {
        public FilterController(IMediator mediator) : base(mediator) { }

        // GET: api/<CarController>
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadFiltersQuery());
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost("/api/filter/generateFilterData")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> GenerateFiltersData([FromBody] WriteFiltersCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
