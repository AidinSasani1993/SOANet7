using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class Order : BaseEntity
    {
        public double TotalAmount { get; private set; }
        public bool IsCanceled { get; private set; }
        public List<CustomerTicket> CustomerTickets { get; private set; }
        public Guid CustomerRef { get; private set; }
        public Customer Customer { get; private set; }

        public Order(double totalAmount, Guid customerRef)
        {
            TotalAmount = totalAmount;
            CustomerRef = customerRef;
            IsCanceled = false;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
