using AutoMapper;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.Person;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Factories;
using OnlineShopping.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Services
{
    [ScopedService]
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;
        private readonly PersonFactoryService personFactoryService;

        #region [-ctor-]
        public PersonService(IPersonRepository personRepository,
                             IMapper mapper,
                             PersonFactoryService personFactoryService)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
            this.personFactoryService = personFactoryService;
        }
        #endregion

        #region [-Methods-]

        #region [-CreateAsync(CreateOrUpdatePerson input)-]
        public async Task<OperationResult> CreateAsync(CreateOrUpdatePerson input)
        {
            var operation = new OperationResult();

            if (await personRepository.Exists(a => a.IdentityCode == input.IdentityCode))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var person = new Person(input.IdentityCode, input.FirstName, input.LastName);

            await personRepository.InsertAsync(person);
            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdatePerson input)-]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdatePerson input)
        {
            var operation = new OperationResult();
            var person = await personRepository.GetByIdAsync(id);

            if (await personRepository.Exists(a => a.Id != id))
            {
                return operation.Failed("Not");
            }

            person.Modify(input.IdentityCode, input.FirstName, input.LastName);

            await personRepository.UpdateAsync(person);

            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #region [-GetByIdAsync(Guid id)-]
        public async Task<PersonDto> GetByIdAsync(Guid id)
        {
            var query = await personRepository.GetByIdAsync(id);
            return mapper.Map<PersonDto>(query);
        }
        #endregion

        #region [-GetAsync()-]
        public async Task<List<PersonDto>> GetAsync()
        {
            var query = await personRepository.GetAllAsync();
            return mapper.Map<List<PersonDto>>(query);
        }
        #endregion

        #region [-CreateByIdentityCodeAsync(string identityCode, CreateOrUpdatePerson input)-]
        public async Task<PersonDto> CreateByIdentityCodeAsync(CreateOrUpdatePerson input)
        {
            var person = await personFactoryService.CreateAsync
                                            (input.IdentityCode,
                                             input.FirstName,
                                             input.LastName);
            await personRepository.InsertAsync(person);
            return mapper.Map<Person, PersonDto>(person);
        }
        #endregion

        #region [-GetCountPeopleAsync()-]
        public async Task<int> GetCountPeopleAsync()
        {
            var count = await personRepository.GetCountPeopleAsync();
            return count;
        }
        #endregion

        #region [-UpdateIdentityCodeAsync(Guid id, string Identity)-]
        public async Task<OperationResult> UpdateIdentityCodeAsync(Guid id, string identityCode)
        {
            var operation = new OperationResult();
            var person = await personRepository.GetByIdAsync(id);

            //if (await personRepository.Exists(a => a.Id != id))
            //{
            //    return operation.NotFound(ApplicationMessages.RecordNotFound);
            //}

            person.ModifyIdentityCode(identityCode);
            await personRepository.UpdateAsync(person);
            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #region [-GetIdByIdentityCodeAsync(string identityCode)-]
        public async Task<IdPersonDto> GetIdByIdentityCodeAsync(string identityCode)
        {
            var id = await personRepository.GetByIdentityCodeAsync(identityCode);
            return mapper.Map<IdPersonDto>(id);
        }
        #endregion

        #region [-GetIdByIdentityCodeAsync()-]
        public async Task<List<IdPersonDto>> GetIdAsync()
        {
            var query = await personRepository.GetAllAsync();
            return mapper.Map<List<IdPersonDto>>(query);
        }
        #endregion

        public async Task<List<PersonDto>> GetPeopleWithSelectIdentityCode(string identityCode)
        {
            var query = await personRepository.GetPeopleWithSelectIdentityCode(identityCode);
            return mapper.Map<List<PersonDto>>(query);
        }

        #endregion
    }
}
