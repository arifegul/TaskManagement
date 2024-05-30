using MediatR;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Commands.TaskCommands
{
    public record UpdateTaskCommand
        (
        int TaskId,
        int UserId,
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate
        )
        : IRequest<Response<TaskResponse>>;
}
