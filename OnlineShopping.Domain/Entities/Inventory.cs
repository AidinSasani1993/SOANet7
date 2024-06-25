using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public Guid ProductRef { get; private set; }
        public Product Product { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> InventoryOperations { get; private set; }

        public Inventory(Guid productRef, double unitPrice)
        {
            ProductRef = productRef;
            UnitPrice = unitPrice;
            InStock = false;
        }

        public void Modify(Guid productRef, double unitPrice)
        {
            ProductRef = productRef;
            UnitPrice = unitPrice;
        }

        public long CalculateCurrentCount()
        {
            var plus = InventoryOperations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = InventoryOperations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            InventoryOperations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Reduce(long count, long operatorId, string description, long orderRef)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorId, currentCount, description, orderRef, Id);
            InventoryOperations.Add(operation);
            InStock = currentCount > 0;
        }
    }
}
