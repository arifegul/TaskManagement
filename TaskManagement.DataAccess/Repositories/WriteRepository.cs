using Microsoft.EntityFrameworkCore;
using TaskManagement.Business.Repositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.DataAccess.Repositories
{
    public class WriteRepository<T>(TaskManagementDbContext dbContext) : IWriteRepository<T> where T : BaseEntity
	{
		private readonly TaskManagementDbContext _dbContext = dbContext;
		public DbSet<T> Table => _dbContext.Set<T>();

		public async Task<int> Create(T entity)
		{
			await Table.AddAsync(entity);
			return await Save();
		}

		public async Task<int> Delete(T entity)
		{
			Table.Remove(entity);
			return await Save();
		}

		public async Task<int> Update(T entity)
		{
			Table.Update(entity);
			return await Save();

		}

		private async Task<int> Save()
			=> await _dbContext.SaveChangesAsync();
	}
}
