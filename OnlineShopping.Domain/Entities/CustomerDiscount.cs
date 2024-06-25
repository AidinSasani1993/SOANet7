using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class CustomerDiscount : BaseEntity
    {
        public Guid ProductRef { get; private set; }
        public Product Product { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Reason { get; private set; }

        public CustomerDiscount(Guid productRef,
                                int discountRate, 
                                DateTime startDate, 
                                DateTime endDate, 
                                string reason)
        {
            ProductRef = productRef;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public void Modify(Guid productRef,
                                int discountRate,
                                DateTime startDate,
                                DateTime endDate,
                                string reason)
        {
            ProductRef = productRef;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }
    }
}
