using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts.Services
{
    [ScopedService]
    public interface IOrderService
    {
        Task<int> GetCountOrdersAsync();
    }
}
