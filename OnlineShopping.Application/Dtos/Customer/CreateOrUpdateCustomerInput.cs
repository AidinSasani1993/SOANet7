namespace OnlineShopping.Application.Dtos.Customer
{
    public class CreateOrUpdateCustomerInput
    {
        public Guid PersonRef { get; set; }
        public string Code { get; set; }
    }
}
