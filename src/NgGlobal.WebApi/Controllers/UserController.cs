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
        [MapToApiVersion("1")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = UserType.Admin)]
        [Route("/api/user/get/{id}")]
        [MapToApiVersion("2")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery() { Id = id }); ;
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = UserType.Admin)]
        [Route("/api/user/getAll")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _mediator.Send(new ReadAllUsersQuery());
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = UserType.Admin)]
        [Route("/api/user/getAllAdmins")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var response = await _mediator.Send(new ReadAllAdminsQuery());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserType.Admin)]
        [Route("/api/user/registerAdmin")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = UserType.Admin)]
        [Route("/api/user/getByEmail")]
        [MapToApiVersion("2")]
        public async Task<IActionResult> GetByEmail([FromBody] GetUserByEmailCommand request)
        {
            if (request == null) { return BadRequest(ModelState); }

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("/api/User/LogIn")]
        [MapToApiVersion("2")]
        [MapToApiVersion("1")]
        public async Task<IActionResult> LogIn([FromBody] LogInUserCommand item)
        {
            var token = await _mediator.Send(item);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { jwt = token });
        }

        [HttpPost(nameof(CreateRoleCommand))]
        [MapToApiVersion("2")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok();
        }


        [HttpPost(nameof(ChangeUserStatus))]
        [Authorize(Roles = UserType.Admin)]
        [MapToApiVersion("2")]
        public async Task<IActionResult> ChangeUserStatus(ChangeUserStatusCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
