using TaskManagement.Business.Repositories.UserRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Repositories.UserRepositories
{
    public class UserReadRepository(TaskManagementDbContext dbContext) : ReadRepository<User>(dbContext), IUserReadRepository
    {
	}
}
