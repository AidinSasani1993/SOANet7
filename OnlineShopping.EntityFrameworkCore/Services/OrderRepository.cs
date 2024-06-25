using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using OnlineShopping.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.EntityFrameworkCore.Services
{
    [ScopedService]
    public class OrderRepository : BaseRepository<ShopManagementDbContext, Order, Guid>, IOrderRepository
    {
        #region [-ctor-]
        public OrderRepository(ShopManagementDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [-GetCountOrdersAsync()-]
        public async Task<int> GetCountOrdersAsync()
        {
            var count = DbSet.CountAsync();
            return await count;
        }
        #endregion

    }
}
