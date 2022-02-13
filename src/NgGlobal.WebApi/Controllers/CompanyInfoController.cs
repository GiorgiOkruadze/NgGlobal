using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new RealAllCompanyInfoQuery());
            return Ok(response);
        }

        // GET api/<CompanyServiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadCompanyInfoByIdQuery(){ CompanyInfoId = id});
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCompanyInfoCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCompanyInfoCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCompanyInfoCommand() { CompanyInfoId = id });
            return Ok(response);
        }
    }
}
