using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.Contract.Abstracts;

namespace OnlineShopping.EntityFrameworkCore.Frameworks.Bases
{
    public class BaseGetRepository<K_DbContext, TEntity, T_Key> : IGetRepository<TEntity, T_Key>
                                                where TEntity : class
                                                where K_DbContext : DbContext
    {
        #region [-props-]
        public virtual K_DbContext DbContext { get; set; }
        public virtual DbSet<TEntity> DbSet { get; set; }
        #endregion

        #region [-ctor-]
        public BaseGetRepository(K_DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        #endregion

        public async Task<List<TEntity>> GetAllAsync()
        {
            var query = DbSet.AsNoTracking().ToListAsync();
            return await query;
        }

        public async Task<TEntity> GetByIdAsync(T_Key id)
        {
            var query = await DbSet.FindAsync(id);
            return query;
        }
    }
}
