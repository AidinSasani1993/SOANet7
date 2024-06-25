using OnlineShopping.Domain.Contract.Abstracts;
using OnlineShopping.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Repositories
{
    [ScopedService]
    public interface IOrderItemRepository : IRepository<Order, Guid>
    {
        Task<List<OrderItem>> GetItems(Guid orderRef);
    }
}
