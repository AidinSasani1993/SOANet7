using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class AdminTicket : BaseEntity
    {
        public Guid? OrderRef { get; private set; }
        public Order Order { get; private set; }
        public string Text { get; private set; }
        public bool IsOpen { get; private set; }
        public DateTime CloseDate { get; private set; }

        public AdminTicket(Guid? orderRef, string text, bool isOpen, DateTime closeDate)
        {
            OrderRef = orderRef;
            Text = text;
            IsOpen = isOpen;
            CloseDate = closeDate;
        }

        public void Modify(Guid? orderRef, string text, bool isOpen, DateTime closeDate)
        {
            OrderRef = orderRef;
            Text = text;
            IsOpen = isOpen;
            CloseDate = closeDate;
        }
    }
}
