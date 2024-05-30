using MediatR;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Queries.TaskQueries
{
    public record GetTaskByIdQuery
        (
            int Id
        )
        : IRequest<Response<TaskResponse>>;
}
