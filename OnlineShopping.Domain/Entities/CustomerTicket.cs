using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class CustomerTicket : BaseEntity
    {
        public Guid? OrderRef { get; private set; }
        public Order Order { get; private set; }
        public string Text { get; private set; }
        public bool IsOpen { get; set; }
        public DateTime CloseDate { get; private set; }

        public CustomerTicket(Guid? orderRef, string Text)
        {
            OrderRef = orderRef;
            this.Text = Text;
            IsOpen = true;
        }

        public void Modify(Guid? orderRef, string Text)
        {
            OrderRef = orderRef;
            this.Text = Text;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
            CloseDate = DateTime.Now;
        }
    }
}
