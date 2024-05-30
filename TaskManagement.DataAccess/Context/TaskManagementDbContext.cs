using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities.Entities;

namespace TaskManagement.DataAccess.Context
{
    public class TaskManagementDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskDetail> TaskDetail { get; set; }
    }
}
