using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.Person;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts.Services.PersonServices
{
    [ScopedService]
    public interface IGetPersonService
    {
        Task<PersonDto> GetByIdAsync(Guid id);
        Task<List<PersonDto>> GetAsync();
        Task<int> GetCountPeopleAsync();
        Task<IdPersonDto> GetIdByIdentityCodeAsync(string identityCode);
    }
}
