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
   
    public class ContractController : BaseController
    {
        public ContractController(IMediator mediator) : base(mediator) { }

        // GET: api/<CarController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new ReadAllContractsQuery());
            return Ok(response);
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new ReadContractByIdQuery() { ContractId = id});
            return Ok(response);
        }

        // GET api/<CarController>/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var response = await _mediator.Send(new ReadContractByUserIdQuery() { UserId = userId });
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContractCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateContractCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response)
;
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteContractCommand() { ContractId = id });
            return Ok(response);
        }
    }
}
