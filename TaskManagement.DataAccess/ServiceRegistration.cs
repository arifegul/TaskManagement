using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Business.Repositories.RoleRepositories;
using TaskManagement.Business.Repositories.TaskDetailRepositories;
using TaskManagement.Business.Repositories.TaskRepositories;
using TaskManagement.Business.Repositories.UserRepositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.DataAccess.Repositories.RoleRepositories;
using TaskManagement.DataAccess.Repositories.TaskDetailRepositories;
using TaskManagement.DataAccess.Repositories.TaskRepositories;
using TaskManagement.DataAccess.Repositories.UserRepositories;

namespace TaskManagement.DataAccess
{
    public static class ServiceRegistration
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddDbContext<TaskManagementDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
			services.AddScoped<IUserReadRepository, UserReadRepository>();
			services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            services.AddScoped<ITaskReadRepository, TaskReadRepository>();
			services.AddScoped<ITaskWriteRepository, TaskWriteRepository>();
            services.AddScoped<ITaskDetailReadRepository, TaskDetailReadRepository>();
            services.AddScoped<ITaskDetailWriteRepository, TaskDetailWriteRepository>();
        }
	}
}
