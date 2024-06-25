using OnlineShopping.Domain.Framework.Bases;

namespace OnlineShopping.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Guid PersonRef { get; private set; }
        public Person Person { get; private set; }
        public string Code { get; private set; }
        public List<Order> Order { get; private set; }

        //public Guid AccountRef { get; private set; }
        //public Account Account { get; private set; }

        #region [-ctors-]
        public Customer(Guid? personRef,
                        string code,
                        string identityCode,
                        string firstName,
                        string lastName)
        {
            PersonRef = personRef.Value;
            Code = code;
            if (personRef is null)
            {
                this.PersonRef = personRef.Value;
            }
            else
            {
                new Person(identityCode,
                           firstName,
                           lastName);
            }
        }

        public Customer(Guid personRef,
                        string code)
        {
            PersonRef = personRef;
            Code = code;
        }
        #endregion

        public void Modify(string code)
        {
            this.Code = code;
        }

    }
}
