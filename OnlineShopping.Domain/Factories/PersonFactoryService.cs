using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Factories
{
    [ScopedService]
    public class PersonFactoryService
    {
        private readonly IPersonRepository personRepository;

        #region [-ctor-]
        public PersonFactoryService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        } 
        #endregion

        #region [-CreateAsync(string identityCode, string firstName, string lastName)-]
        public async Task<Person> CreateAsync(string identityCode, string firstName, string lastName)
        {
            var existPerson = await personRepository.GetByIdentityCodeAsync(identityCode);
            if (existPerson == null)
            {
                return new Person(identityCode, firstName, lastName);
            }
            else
            {
                return null;
            }
        } 
        #endregion
    }
}
