using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
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
using TaskManagement.Infrastructure.APIs;

namespace TaskManagement.Business.Handlers.TaskHandlers.QueryHandlers
{
    public class GetAllTaskHandler(ITaskReadRepository repository, ITaskDetailReadRepository detailRepository, IMapper mapper, IMemoryCache cache) : IRequestHandler<GetAllTaskQuery, Response<List<TaskResponse>>>
    {
        private readonly ITaskReadRepository _repository = repository;
        private readonly ITaskDetailReadRepository _detailRepository = detailRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IMemoryCache _cache = cache;

        public async Task<Response<List<TaskResponse>>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            List<TaskResponse> responses = [];

            if (!_cache.TryGetValue("tasks", out List<TaskResponse> cachedTasks))
            {
                var getAllTask = await _repository.GetAllIncluding(x => x.User);
                var getAllTaskDetail = await _detailRepository.GetAll();

                foreach (var task in getAllTask)
                {
                    var getTaskDetail = getAllTaskDetail.FirstOrDefault(x => x.TaskId == task.Id);

                    TaskResponse response = new()
                    {
                        Id = task.Id,
                        Name = task.Name,
                        Status = task.Status,
                        CreatedBy = task.CreatedBy,
                        CreatedDate = task.CreatedDate,
                        ModifiedBy = task.ModifiedBy,
                        ModifiedDate = task.ModifiedDate,
                        TaskDetail = _mapper.Map<TaskDetailResponse>(getTaskDetail),
                        User = _mapper.Map<UserResponse>(task.User)
                    };

                    responses.Add(response);
                }

                _cache.Set("tasks", responses, TimeSpan.FromMinutes(2));
            }
            else
            {
                responses = cachedTasks;
            }

            return Response<List<TaskResponse>>.Success(responses, 200);
        }
    }
}
