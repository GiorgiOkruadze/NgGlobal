using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NgGlobal.ApplicationServices.Commands;
using NgGlobal.ApplicationServices.Queries;
using NgGlobal.ApplicationServices.Services.Abstractions;
using NgGlobal.WebApi.AuthorizeConstatnts;
using NgGlobal.WebApi.Controllers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NgGlobal.WebApp.ApiControllers
{
   
    public class FilterController : BaseController
    {
        private readonly IFilterService _fileService = default;

        public FilterController(IMediator mediator, IFilterService fileService) : base(mediator) 
        { 
            _fileService= fileService;
        }

        // GET: api/<CarController>
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Get()
        {
            var response = await _fileService.ReadFilterAsync();
            return Ok(response);
        }

        [Authorize(Roles = UserType.Admin)]
        [HttpPost("/api/filter/generateFilterData")]
        [ApiVersion("2.0")]
        public async Task<IActionResult> GenerateFiltersData()
        {
            var response = await _fileService.ReadFilterAsync();
            return Ok(response);
        }
    }
}
