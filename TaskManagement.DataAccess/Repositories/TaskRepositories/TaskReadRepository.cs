using TaskManagement.Business.Repositories.TaskRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Repositories.TaskRepositories
{
    public class TaskReadRepository(TaskManagementDbContext dbContext) : ReadRepository<Tasks>(dbContext), ITaskReadRepository
	{
	}
}
