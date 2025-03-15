using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo1.CSProjeDemo1.Core.BaseRepository.Interface
{
    public interface IBaseRepository<T>
    {
		Task<T?> GetByIdAsync(Guid Id);
		Task<T?> GetAsync(Expression<Func<T, bool>> expression);
		Task<IQueryable<T>> GetAllAsync();
		Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task DeleteAsync(T entity);
		Task<int> SaveChangesAsync();
	}
}
