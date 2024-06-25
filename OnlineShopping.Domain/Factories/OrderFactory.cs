using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;

namespace OnlineShopping.Domain.Factories
{
    public class OrderFactory
    {
        private readonly IOrderRepository orderRepository;

        #region [-ctor-]
        public OrderFactory(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        #endregion

    }
}
