using Microsoft.EntityFrameworkCore;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using OnlineShopping.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.EntityFrameworkCore.Services
{
    [ScopedService]
    public class PersonRepository : BaseRepository<ShopManagementDbContext, Person, Guid>,
                                    IPersonRepository
    {
        #region [-ctor-]
        public PersonRepository(ShopManagementDbContext dbContext) : base(dbContext)
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

        public async Task<List<Person>> GetPeopleWithSelectIdentityCode(string identityCode)
        {
            var q = DbSet.Where(a => a.IdentityCode.StartsWith(identityCode));
            return await q.ToListAsync();
        }

    }
}
