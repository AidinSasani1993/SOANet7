using OnlineShopping.Application.Dtos.Person;

namespace OnlineShopping.Application.Dtos.Customer
{
    public class CustomerDto
    {
        public PersonDto Person { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
    }
}
