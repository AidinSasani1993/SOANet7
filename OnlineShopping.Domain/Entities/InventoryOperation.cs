namespace OnlineShopping.Domain.Entities
{
    public class InventoryOperation 
    {
        public Guid Id { get; private set; }
        public Guid InventoryRef { get; private set; }
        public Inventory Inventory { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; private set; }
        public long OrderRef { get; private set; }
        public Order Order { get; private set; }
        
        protected InventoryOperation()
        {

        }

        public InventoryOperation(bool operation,
                                  long count, 
                                  long operatorId, 
                                  long currentCount,
                                  string description, 
                                  long orderRef,
                                  Guid invetoryRef)
        {
            Operation = operation;
            Count = count;
            OperatorId = operatorId;
            CurrentCount = currentCount;
            Description = description;
            OrderRef = orderRef;
            InventoryRef = invetoryRef;
            OperationDate = DateTime.Now;
        }
    }
}
