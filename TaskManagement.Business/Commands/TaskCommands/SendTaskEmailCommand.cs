using MediatR;
using TaskManagement.Business.Shared;

namespace TaskManagement.Business.Commands.TaskCommands
{
    public record SendTaskEmailCommand
        (
            string ToEmail,
            string TaskName,
            string Body
        )
        : IRequest<Response<bool>>;
}
