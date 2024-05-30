using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business.Commands.TaskCommands;
using TaskManagement.Business.Queries.TaskQueries;
using TaskManagement.Business.Shared;

namespace TaskManagement.API.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(IMediator mediator) : CustomBaseController
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("createTask")]
        public async Task<IActionResult> CreateTask(CreateTaskCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.Data != null)
            {
                var body = $"'{response.Data.Name}' task has been created. Please check your task. If you have questions, you can contact your manager.";
                var email = new SendTaskEmailCommand(
                    response.Data.User.Email,
                    response.Data.Name,
                    body
                );

                BackgroundJob.Enqueue<TaskController>(controller => controller.SendTaskEmail(email));
            }

            return CreateActionResultInstance(response);
        }

        [HttpPost("sendTaskEmail")]
        public async Task<IActionResult> SendTaskEmail(SendTaskEmailCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [AllowAnonymous]
        [HttpGet("getTaskById")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var response = await _mediator.Send(new GetTaskByIdQuery(id));

            return CreateActionResultInstance(response);
        }

        [HttpPost("updateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskCommand command)
        {
            var response = await _mediator.Send(command);

            if (response.Data != null)
            {
                var body = $"'{response.Data.Name}' task has been updated. Please check your task. If you have questions, you can contact your manager.";

                var email = new SendTaskEmailCommand(
                    response.Data.User.Email,
                    response.Data.Name,
                    body
                );

                BackgroundJob.Enqueue<TaskController>(controller => controller.SendTaskEmail(email));
            }

            return CreateActionResultInstance(response);
        }

        [AllowAnonymous]
        [HttpGet("getAllTask")]
        public async Task<IActionResult> GetAllTask()
        {
            var response = await _mediator.Send(new GetAllTaskQuery());

            return CreateActionResultInstance(response);
        }

        /// <summary>
        /// The status of the tasks is updated.
        /// </summary>
        [AllowAnonymous]
        [HttpPost("updateTaskStatus")]
        public async Task<IActionResult> UpdateTaskStatus(UpdateTaskStatusCommand command)
        {
            var response = await _mediator.Send(command);

            return CreateActionResultInstance(response);
        }

        [HttpPost("deleteTask")]
        public async Task<IActionResult> DeleteTask(DeleteTaskCommand command)
        {
            var response = await _mediator.Send(command);
            return CreateActionResultInstance(response);
        }
    }
}
