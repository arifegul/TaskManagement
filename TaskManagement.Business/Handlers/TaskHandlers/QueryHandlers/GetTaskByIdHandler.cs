using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Business.Queries.TaskQueries;
using TaskManagement.Business.Repositories.TaskDetailRepositories;
using TaskManagement.Business.Repositories.TaskRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Entities;
using TaskManagement.Infrastructure.APIs;

namespace TaskManagement.Business.Handlers.TaskHandlers.QueryHandlers
{
    public class GetTaskByIdHandler(ITaskReadRepository repository, ITaskDetailReadRepository detailRepository, IMapper mapper) : IRequestHandler<GetTaskByIdQuery, Response<TaskResponse>>
    {
        private readonly ITaskReadRepository _repository = repository;
        private readonly ITaskDetailReadRepository _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<TaskResponse>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var getTask = await _repository.Find(x => x.Id == request.Id);
            if (getTask == null)
                return Response<TaskResponse>.Fail("Task could not found", 409);

            var getTaskDetail = await _detailRepository.Find(x => x.TaskId == getTask.Id);
            if (getTaskDetail == null)
                return Response<TaskResponse>.Fail("Task detail could not found", 409);

            var getUser = await TaskManagementAPIs.GetUserById<UserResponse>(getTask.UserId);
            if (getUser == null)
                return Response<TaskResponse>.Fail("User cannot found!", 409);

            TaskResponse response = new()
            {
                Id = getTask.Id,
                Name = getTask.Name,
                Status = getTask.Status,
                CreatedBy = getTask.CreatedBy,
                CreatedDate = getTask.CreatedDate,
                ModifiedBy = getTask.ModifiedBy,
                ModifiedDate = getTask.ModifiedDate,
                TaskDetail = _mapper.Map<TaskDetailResponse>(getTaskDetail),
                User = _mapper.Map<UserResponse>(getUser)
            };

            return Response<TaskResponse>.Success(response, 200);
        }
    }
}
