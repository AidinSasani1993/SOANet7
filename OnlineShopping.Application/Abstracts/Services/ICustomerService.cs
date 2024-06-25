using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.Customer;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts.Services
{
    [ScopedService]
    public interface ICustomerService
    {
        Task<int> GetCountCustomersAsync();
        Task<int> GetCountOrderOfCustomerAsync();
        Task<OperationResult> CreateCustomerAsync(CreateOrUpdateCustomerInput input);
        Task<OperationResult> UpdateCustomerAsync(Guid id, UpdateCustomerDto input);
        Task<List<CustomerDto>> GetAllRecordAsync();
        Task<OperationResult> DeleteAsync(Guid id);
        Task<OperationResult> ActiveAsync(Guid id);
    }
}
