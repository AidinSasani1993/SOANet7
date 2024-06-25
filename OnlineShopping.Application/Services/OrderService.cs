using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Services
{
    [ScopedService]
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        #region [-ctor-]
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        #endregion

        #region [-GetCountOrdersAsync()-]
        public async Task<int> GetCountOrdersAsync()
        {
            return await orderRepository.GetCountOrdersAsync();
        } 
        #endregion
    }
}
