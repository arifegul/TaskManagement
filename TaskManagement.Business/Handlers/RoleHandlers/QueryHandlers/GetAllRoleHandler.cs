using AutoMapper;
using MediatR;
using TaskManagement.Business.Queries.RoleQueries;
using TaskManagement.Business.Repositories.RoleRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;

namespace TaskManagement.Business.Handlers.RoleHandlers.QueryHandlers
{
    public class GetAllRoleHandler(IRoleReadRepository repository, IMapper mapper) : IRequestHandler<GetAllRoleQuery, Response<List<RoleResponse>>>
    {
        private readonly IRoleReadRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<List<RoleResponse>>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var getRoles = await _repository.GetAll();

            var response = _mapper.Map<List<RoleResponse>>(getRoles);

            return Response<List<RoleResponse>>.Success(response, 200);
        }
    }
}
