using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories.PersonRepositories;
using OnlineShopping.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.EntityFrameworkCore.Services.PersonServices
{
    [ScopedService]
    public class GetPersonRepository : BaseGetRepository<ShopManagementDbContext, Person, Guid>,
                                       IGetPersonRepository
    {
        #region [-ctor-]
        public GetPersonRepository(ShopManagementDbContext dbContext) : base(dbContext)
        {
        } 
        #endregion

        #region [-GetByIdentityCodeAsync(string identityCode)-]
        public async Task<Person> GetByIdentityCodeAsync(string identityCode)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.IdentityCode == identityCode);
        }
        #endregion

        #region [-GetCountPeopleAsync()-]
        public async Task<int> GetCountPeopleAsync()
        {
            return await DbSet.CountAsync();
        }
        #endregion

    }
}
