using AutoMapper;
using MediatR;
using TaskManagement.Business.Commands.TaskCommands;
using TaskManagement.Business.Repositories.TaskDetailRepositories;
using TaskManagement.Business.Repositories.TaskRepositories;
using TaskManagement.Business.Shared;
using TaskManagement.Entities.Dtos;
using TaskManagement.Entities.Entities;
using TaskManagement.Infrastructure.APIs;

namespace TaskManagement.Business.Handlers.TaskHandlers.CommandHandlers
{
    public class DeleteTaskHandler(ITaskWriteRepository repository, ITaskDetailWriteRepository detailRepository, IMapper mapper) : IRequestHandler<DeleteTaskCommand, Response<bool>>
    {
        private readonly ITaskWriteRepository _repository = repository;
        private readonly ITaskDetailWriteRepository _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Response<bool>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var getTaskResponse = await TaskManagementAPIs.GetTaskById<TaskResponse>(request.TaskId);
            if (getTaskResponse == null)
                return Response<bool>.Fail("Task could not found!", 409);

            bool isDeleted;

            var getTaskDetail = _mapper.Map<TaskDetail>(getTaskResponse.TaskDetail);

            isDeleted = await _detailRepository.Delete(getTaskDetail) >= 1;
            if (!isDeleted)
                return Response<bool>.Fail("Error while updating", 409);

            var getTask = _mapper.Map<Tasks>(getTaskResponse);

            isDeleted = await _repository.Delete(getTask) >= 1;
            if (!isDeleted)
                return Response<bool>.Fail("Error while updating", 409);

            return Response<bool>.Success(true, 201);
        }
    }
}
