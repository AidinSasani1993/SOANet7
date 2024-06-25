using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using OnlineShopping.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.EntityFrameworkCore.Services
{
    [ScopedService]
    public class ProductRepository : BaseRepository<ShopManagementDbContext, Product, Guid>, IProductRepository
    {
        #region [-ctor-]
        public ProductRepository(ShopManagementDbContext dbContext) : base(dbContext)
        {

        } 
        #endregion
    }
}
