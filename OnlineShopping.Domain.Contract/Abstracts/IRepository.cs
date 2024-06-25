using System.Linq.Expressions;

namespace OnlineShopping.Domain.Contract.Abstracts
{
    public interface IRepository<TEntity,T_Key> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(T_Key id);
        Task<List<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity input);
        Task UpdateAsync(TEntity input);
        Task DeleteAsync(T_Key id);
        Task<bool> Exists(Expression<Func<TEntity, bool>> expression);
        Task SaveChangesAsync();
        List<TEntity> GetAll();
    }
}
