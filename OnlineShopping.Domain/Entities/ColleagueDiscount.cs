using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class ColleagueDiscount : BaseEntity
    {
        public Guid ProductRef { get; private set; }
        public Product Product { get; private set; }
        public int DiscountRate { get; private set; }

        public ColleagueDiscount(Guid productRef, int discountRate)
        {
            ProductRef = productRef;
            DiscountRate = discountRate;
        }

        public void Modify(Guid productRef, int discountRate)
        {
            ProductRef = productRef;
            DiscountRate = discountRate;
        }
    }
}
