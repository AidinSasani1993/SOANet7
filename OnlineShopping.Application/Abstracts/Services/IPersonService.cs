using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.Person;
using OnlineShopping.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts.Services
{
    [ScopedService]
    public interface IPersonService
    {
        Task<OperationResult> CreateAsync(CreateOrUpdatePerson input);
        Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdatePerson input);
        Task<PersonDto> GetByIdAsync(Guid id);
        Task<List<PersonDto>> GetAsync();
        Task<PersonDto> CreateByIdentityCodeAsync(CreateOrUpdatePerson input);
        Task<int> GetCountPeopleAsync();
        Task<OperationResult> UpdateIdentityCodeAsync(Guid id, string identityCode);
        Task<IdPersonDto> GetIdByIdentityCodeAsync(string identityCode);
        Task<List<IdPersonDto>> GetIdAsync();
        Task<List<PersonDto>> GetPeopleWithSelectIdentityCode(string identityCode);
    }
}
