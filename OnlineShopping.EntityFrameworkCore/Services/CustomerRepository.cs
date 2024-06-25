using Microsoft.EntityFrameworkCore;
using OnlineShopping.Application.Dtos.Customer;
using OnlineShopping.Application.Dtos.Person;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using OnlineShopping.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.EntityFrameworkCore.Services
{
    [ScopedService]
    public class CustomerRepository : BaseRepository<ShopManagementDbContext, Customer, Guid> 
                                    , ICustomerRepository
    {
        #region [-ctor-]
        public CustomerRepository(ShopManagementDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [-GetCountCustomersAsync()-]
        public async Task<int> GetCountCustomersAsync()
        {
            return await DbSet.CountAsync();
        }
        #endregion

        #region [-GetCountOrderOfCustomerAsync()-]
        public async Task<int> GetCountOrderOfCustomerAsync()
        {
            var count = await DbSet.Include(a => a.Order).CountAsync();
            return count;
        }
        #endregion

    }
}
