using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using OnlineShopping.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.EntityFrameworkCore.Services
{
    [ScopedService]
    public class ProductCategoryRepository : BaseRepository<ShopManagementDbContext, ProductCategory, Guid>,
                                                                            IProductCategoryRepository
    {
        public ProductCategoryRepository(ShopManagementDbContext dbContext) : base(dbContext)
        {
        }

        #region [-GetByNameAsync(string name)-]
        public async Task<ProductCategory> GetByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Name == name);
        }
        #endregion

        #region [-GetSlugById(Guid id)-]
        public async Task<string> GetSlugById(Guid id)
        {
            return DbSet.Select(a => new { a.Id, a.Slug })
                .FirstOrDefault(a => a.Id == id).Slug;
        }
        #endregion

        #region [-GetCountProductCategoryAsync()-]
        public async Task<int> GetCountProductCategoryAsync()
        {
            var count = await DbSet.CountAsync();
            return count;
        } 
        #endregion
    }
}
