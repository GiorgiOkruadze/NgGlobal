using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Commands.User;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.WebApi.AuthorizeConstatnts;
using NgGlobal.WebApi.Controllers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NgGlobal.WebApp.ApiControllers
{

    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator) { }

        // POST api/<CarController>
        [HttpPost]
        [Route("/api/user/registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserType.Admin)]
        [Route("/api/user/registerAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("/api/User/LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInUserCommand item)
        {
            var token = await _mediator.Send(item);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new {jwt=token});
        }

        [HttpPost(nameof(CreateRoleCommand))]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok();
        }

    }
}
