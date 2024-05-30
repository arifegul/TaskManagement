using MediatR;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Queries.RoleQueries
{
    public class GetAllRoleQuery : IRequest<Response<List<RoleResponse>>>;
}
