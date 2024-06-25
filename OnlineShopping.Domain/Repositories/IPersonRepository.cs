using OnlineShopping.Domain.Contract.Abstracts;
using OnlineShopping.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Repositories
{
    [ScopedService]
    public interface IPersonRepository : IRepository<Person, Guid>
    {
        Task<Person> GetByIdentityCodeAsync(string identityCode);
        Task<int> GetCountPeopleAsync();
        Task<List<Person>> GetPeopleWithSelectIdentityCode(string identityCode);
    }
}
