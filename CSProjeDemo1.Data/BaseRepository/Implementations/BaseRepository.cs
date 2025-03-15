using CSProjeDemo1.Core.Models.BaseEntity;
using CSProjeDemo1.CSProjeDemo1.Core.BaseRepository.Interface;
using CSProjeDemo1.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace CSProjeDemo1.CSProjeDemo1.Core.BaseRepository.Implementations
{
	public class BaseRepository<T> : IBaseRepository<T> where T :BaseEntity
	{
		private readonly AppDbContext _context;
		private readonly DbSet<T> _dbSet;

		public BaseRepository(AppDbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}
		public async Task<T> AddAsync(T entity)
		{
			entity.Id = Guid.NewGuid();
			var entry = await _dbSet.AddAsync(entity);
			return entry.Entity;
		}

		public Task DeleteAsync(T entity)
		{
			return Task.FromResult(_dbSet.Remove(entity));
		}
		public async Task<IQueryable<T>> GetAllAsync()
		{
			return _dbSet;
		}
		public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
		{
			return _dbSet.Where(expression);
		}	

		public Task<T?> GetAsync(Expression<Func<T, bool>> expression)
		{
			return _dbSet.FirstOrDefaultAsync(expression);
		}

		public async Task<T> UpdateAsync(T entity)
		{
			var entry = await Task.FromResult(_dbSet.Update(entity));
			return entry.Entity;
		}
		public Task<int> SaveChangesAsync()
		{
			return _context.SaveChangesAsync();
		}

		public Task<T?> GetByIdAsync(Guid Id)
		{
			return _dbSet.FirstOrDefaultAsync(e=>e.Id==Id);
		}

		public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
		{
			return expression == null ? _dbSet.AnyAsync() : _dbSet.AnyAsync(expression);
		}
	}
}
