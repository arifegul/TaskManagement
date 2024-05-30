using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Commands.RoleCommands;
using TaskManagement.Business.Queries.RoleQueries;
using TaskManagement.Business.Shared;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController(IMediator mediator) : CustomBaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(CreateRoleCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpGet("getAllRole")]
        public async Task<IActionResult> GetAllRole()
        {
            var response = await _mediator.Send(new GetAllRoleQuery());

            return CreateActionResultInstance(response);
        }
    }
}
