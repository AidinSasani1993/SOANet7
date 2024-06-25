using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid OrderRef { get; private set; }
        public Guid ProductRef { get; private set; }
        public Order Order { get; private set; }
        public Product Product { get; private set; }
        public int Count { get; private set; }
        public double UnitPrice { get; private set; }
        public int DiscountRate { get; private set; }

        public OrderItem(Guid productRef, int count, double unitPrice, int discountRate)
        {
            ProductRef = productRef;
            Count = count;
            UnitPrice = unitPrice;
            DiscountRate = discountRate;
        }
    }
}
