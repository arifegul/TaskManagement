using AutoMapper;
using MediatR;
using TaskManagement.Business.Queries.UserQueries;
using TaskManagement.Business.Repositories.UserRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;
using TaskManagement.Infrastructure.APIs;

namespace TaskManagement.Business.Handlers.UserHandlers.QueryHandlers
{
    public class GetUserByIdHandler(IUserReadRepository repository, IMapper mapper) : IRequestHandler<GetUserByIdQuery, Response<UserResponse>>
    {
        private readonly IUserReadRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var getUser = await _repository.Find(x => x.Status && x.Id == request.Id);
            if (getUser == null)
                return Response<UserResponse>.Fail("User could not found", 409);

            var getRoles = await TaskManagementAPIs.GetAllRole<List<RoleResponse>>();
            var getUserRole = getRoles.Where(x => x.Id == getUser.RoleId).FirstOrDefault();
            var getRole = _mapper.Map<RoleResponse>(getUserRole);

            var response = _mapper.Map<UserResponse>(getUser);
            response.Role = getRole;

            return Response<UserResponse>.Success(response, 200);
        }
    }

}
