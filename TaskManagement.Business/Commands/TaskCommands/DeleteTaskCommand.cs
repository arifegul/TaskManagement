using MediatR;
using TaskManagement.Business.Shared;

namespace TaskManagement.Business.Commands.TaskCommands
{
    public record DeleteTaskCommand
        (
        int TaskId
        )
        : IRequest<Response<bool>>;
}
