using TaskManagement.Business.Repositories.TaskRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Repositories.TaskRepositories
{
    public class TaskWriteRepository(TaskManagementDbContext dbContext) : WriteRepository<Tasks>(dbContext), ITaskWriteRepository
	{
	}
}
