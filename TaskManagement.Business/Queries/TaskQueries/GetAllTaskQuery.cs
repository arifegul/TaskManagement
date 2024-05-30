using MediatR;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Queries.TaskQueries
{
    public class GetAllTaskQuery : IRequest<Response<List<TaskResponse>>>;
}
