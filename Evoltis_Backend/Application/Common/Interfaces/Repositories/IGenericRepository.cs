using Application.Common.Models;
using Domain.Common;
using System.Linq.Expressions;

namespace Application.Common.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
        
        Task<T> GetByEmailAsync(string email);
        
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        
        Task<T> AddAsync(T entity);
        
        Task<T> UpdateAsync(int id, T entity);
        
        Task DeleteAsync(int
            id);
    }
}
