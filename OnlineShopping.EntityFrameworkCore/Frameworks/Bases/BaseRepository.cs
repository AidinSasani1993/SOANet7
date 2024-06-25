using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.Contract.Abstracts;
using System.Linq.Expressions;

namespace OnlineShopping.EntityFrameworkCore.Frameworks.Bases
{
    public class BaseRepository<K_DbContext, TEntity, T_Key> : IRepository<TEntity, T_Key>
                                                                          where TEntity : class
                                                                          where K_DbContext : DbContext
    {
        public virtual K_DbContext DbContext { get; set; }
        public virtual DbSet<TEntity> DbSet { get; set; }

        public BaseRepository(K_DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task DeleteAsync(T_Key id)
        {
            var query = await DbSet.FindAsync(id);
            DbSet.Remove(query);
            await SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<TEntity, bool>> expression)
        {
            return await DbContext.Set<TEntity>().AnyAsync(expression);
        }

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

        public async Task InsertAsync(TEntity input)
        {
            using (DbContext)
            {
                await DbSet.AddAsync(input);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity input)
        {
            DbSet.Attach(input);
            DbContext.Entry(input).State = EntityState.Modified;
            await SaveChangesAsync();
        }

       public List<TEntity> GetAll()
        {
            var query = DbSet.ToList();
            return query;
        }
    }
}
