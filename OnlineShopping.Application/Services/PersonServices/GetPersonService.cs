using AutoMapper;
using OnlineShopping.Application.Abstracts.Services.PersonServices;
using OnlineShopping.Application.Dtos.Person;
using OnlineShopping.Domain.Factories;
using OnlineShopping.Domain.Repositories;
using OnlineShopping.Domain.Repositories.PersonRepositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Services.PersonServices
{
    [ScopedService]
    public class GetPersonService : IGetPersonService
    {
        private readonly IGetPersonRepository getPersonRepository;
        private readonly IMapper mapper;

        #region [-ctor-]
        public GetPersonService(IGetPersonRepository getPersonRepository,
                                IMapper mapper)
        {
            this.getPersonRepository = getPersonRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-Methods-]

        #region [-GetAsync()-]
        public async Task<List<PersonDto>> GetAsync()
        {
            var query = await getPersonRepository.GetAllAsync();
            return mapper.Map<List<PersonDto>>(query);
        }
        #endregion

        #region [-GetByIdAsync(Guid id)-]
        public async Task<PersonDto> GetByIdAsync(Guid id)
        {
            var query = await getPersonRepository.GetByIdAsync(id);
            return mapper.Map<PersonDto>(query);
        }
        #endregion

        #region [-GetCountPeopleAsync()-]
        public async Task<int> GetCountPeopleAsync()
        {
            var count = await getPersonRepository.GetCountPeopleAsync();
            return count;
        }
        #endregion

        #region [-GetIdByIdentityCodeAsync(string identityCode)-]
        public async Task<IdPersonDto> GetIdByIdentityCodeAsync(string identityCode)
        {
            var id = await getPersonRepository.GetByIdentityCodeAsync(identityCode);
            return mapper.Map<IdPersonDto>(id);
        }
        #endregion

        #endregion

    }
}
