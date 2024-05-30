using AutoMapper;
using MediatR;
using TaskManagement.Business.Commands.TaskCommands;
using TaskManagement.Business.Repositories.TaskDetailRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Entities;
using TaskManagement.Infrastructure.APIs;

namespace TaskManagement.Business.Handlers.TaskHandlers.CommandHandlers
{
    public class UpdateTaskStatusHandler(ITaskDetailWriteRepository detailRepository, IMapper mapper) : IRequestHandler<UpdateTaskStatusCommand, Response<bool>>
    {
        private readonly ITaskDetailWriteRepository _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<Response<bool>> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var getTaskResponse = await TaskManagementAPIs.GetTaskById<TaskResponse>(request.TaskId);
            if (getTaskResponse == null)
                return Response<bool>.Fail("Task could not found!", 409);

            var getTaskDetail = _mapper.Map<TaskDetail>(getTaskResponse.TaskDetail);

            getTaskDetail.TaskStatus = request.TaskStatus;
            getTaskDetail.TaskId = request.TaskId;

            var isUpdated = await _detailRepository.Update(getTaskDetail) >= 1;
            if (!isUpdated)
                return Response<bool>.Fail("Error while updating", 409);

            return Response<bool>.Success(isUpdated, 201);
        }
    }
}
