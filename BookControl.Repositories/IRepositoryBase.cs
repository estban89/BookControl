using System.Linq.Expressions;

namespace BookControl.Repositories
{
    public interface IRepositoryBase<TEntity> { 

        Task<ICollection<TEntity>> GetAsync();
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> orderBy);
        Task<TEntity?> GetAsync(string id);
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync();
        Task DeleteAsync(string id);
      
    }
}
