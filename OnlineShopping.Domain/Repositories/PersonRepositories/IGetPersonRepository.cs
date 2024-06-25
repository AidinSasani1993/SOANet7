using OnlineShopping.Domain.Contract.Abstracts;
using OnlineShopping.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Repositories.PersonRepositories
{
    [ScopedService]
    public interface IGetPersonRepository : IGetRepository<Person, Guid>
    {
        Task<Person> GetByIdentityCodeAsync(string identityCode);
        Task<int> GetCountPeopleAsync();
    }
}
