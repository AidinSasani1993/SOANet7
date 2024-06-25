using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string IdentityCode { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<Customer> Customer { get; private set; }

        public Person(string identityCode, string firstName, string lastName)
        {
            IdentityCode = identityCode;
            FirstName = firstName;
            LastName = lastName;
        }

        public void Modify(string identityCode, string firstName, string lastName)
        {
            IdentityCode = identityCode;
            FirstName = firstName;
            LastName = lastName;
        }

        public void ModifyIdentityCode(string identityCode)
        {
            IdentityCode = identityCode;
        }
    }
}
