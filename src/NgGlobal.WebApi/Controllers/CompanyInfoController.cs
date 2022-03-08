using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.WebApi.AuthorizeConstatnts;
using System.Threading.Tasks;

namespace NgGlobal.WebApi.Controllers
{
    public class CompanyInfoController : BaseController
    {
        public CompanyInfoController(IMediator mediator) : base(mediator) { }

        // GET: api/<CarController>
        [HttpGet]
        [ApiVersion("2.0")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new RealAllCompanyInfoQuery());
            return Ok(response);
        }

        [MapToApiVersion("1")]
        [HttpGet("/api/CompanyInfo/Single")]
        public async Task<IActionResult> GetCompanyInfo()
        {
            var response = await _mediator.Send(new GetCompanyInfoQuery());
            return Ok(response);
        }

        // GET api/<CompanyServiceController>/5
        [HttpGet("{id}")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadCompanyInfoByIdQuery(){ CompanyInfoId = id});
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Post([FromBody] CreateCompanyInfoCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Put([FromBody] UpdateCompanyInfoCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpDelete("{id}")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCompanyInfoCommand() { CompanyInfoId = id });
            return Ok(response);
        }
    }
}
