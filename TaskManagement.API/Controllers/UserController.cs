using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Commands.UserCommands;
using TaskManagement.Business.Queries.UserQueries;
using TaskManagement.Business.Shared;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IMediator mediator) : CustomBaseController
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// A request will be sent to this API while the user is registering.
        /// </summary>
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var response = await _mediator.Send(query);

            return CreateActionResultInstance(response);
        }

        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));

            return CreateActionResultInstance(response);
        }
    }
}
