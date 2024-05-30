using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Business.Repositories;
using TaskManagement.DataAccess.Context;
using TaskManagement.Entities.Entities.Common;

namespace TaskManagement.DataAccess.Repositories
{
    public class ReadRepository<T>(TaskManagementDbContext dbContext) : IReadRepository<T> where T : BaseEntity
	{
		private readonly TaskManagementDbContext _dbContext = dbContext;

		public DbSet<T> Table => _dbContext.Set<T>();

        public async Task<T> Find(Expression<Func<T, bool>> expression)
        {
            var entity = await Table.AsNoTracking().FirstOrDefaultAsync(expression);
            return entity ?? throw new Exception("Entity not found.");
        }
        public async Task<List<T>> GetAll()
		=> await Table.AsNoTracking().ToListAsync();

		public async Task<List<T>> GetAllIncluding(params Expression<Func<T, object>>[] includes)
		{
			var query = _dbContext.Set<T>().AsQueryable();

			if (includes != null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));
			}

			return await query.ToListAsync();
		}
	}
}
