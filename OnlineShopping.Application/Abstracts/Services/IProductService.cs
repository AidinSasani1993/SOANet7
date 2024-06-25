using OnlineShopping.Application.Contract;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts.Services
{
    [ScopedService]
    public interface IProductService
    {
        Task<OperationResult> UpdateProductCodeAsync(Guid id, string code);
    }
}
