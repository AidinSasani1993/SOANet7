using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Abstracts.Services.PersonServices;
using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.Person;
using YamlDotNet.Serialization.TypeInspectors;

namespace OnlineShopping.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IGetPersonService getPersonService;

        #region [-ctor-]
        public PersonController(IPersonService personService,
                                IGetPersonService getPersonService)
        {
            this.personService = personService;
            this.getPersonService = getPersonService;
        }
        #endregion

        #region [-Actions-]

        #region [-CreateAsync(CreateOrUpdatePerson input)-]
        [HttpPost("person")]
        public async Task<OperationResult> CreateAsync(CreateOrUpdatePerson input)
        {
            return await personService.CreateAsync(input);
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdatePerson input)-]
        [HttpPut("{id}/person")]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdatePerson input)
        {
            return await personService.UpdateAsync(id, input);
        }
        #endregion

        #region [-GetByIdAsync(Guid id)-]
        [HttpGet("{id}/selfPerson")]
        public async Task<PersonDto> GetByIdAsync(Guid id)
        {
            return await getPersonService.GetByIdAsync(id);
        }
        #endregion

        #region [-GetAsync()-]
        [HttpGet("person")]
        public async Task<List<PersonDto>> GetAsync()
        {
            return await getPersonService.GetAsync();
        }
        #endregion

        #region [-CreateByIdentityCodeAsync(CreateOrUpdatePerson input)-]
        [HttpPost("identity")]
        public async Task<PersonDto> CreateByIdentityCodeAsync(CreateOrUpdatePerson input)
        {
            return await personService.CreateByIdentityCodeAsync(input);
        }
        #endregion

        #region [-GetCountPeopleAsync()-]
        [HttpGet("count")]
        public async Task<int> GetCountPeopleAsync()
        {
            return await getPersonService.GetCountPeopleAsync();
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdatePerson input)-]
        [HttpPatch("{id}/personIdentity")]
        public async Task<OperationResult> UpdateIdentityCodeAsync(Guid id, string identityCode)
        {
            return await personService.UpdateIdentityCodeAsync(id, identityCode);
        }
        #endregion

        #region [-GetIdByIdentityCodeAsync(string identityCode)-]
        [HttpGet("{identityCode}/Person")]
        public async Task<IdPersonDto> GetIdByIdentityCodeAsync(string identityCode)
        {
            return await getPersonService.GetIdByIdentityCodeAsync(identityCode);
        }
        #endregion

        #region [-GetIdAsync()-]
        [HttpGet("personId")]
        public async Task<List<IdPersonDto>> GetIdAsync()
        {
            return await personService.GetIdAsync();
        }
        #endregion

        [HttpGet("person/identityCode")]
        public async Task<List<PersonDto>> GetPeopleWithSelectIdentityCode(string identityCode)
        {
            return await personService.GetPeopleWithSelectIdentityCode(identityCode);
        }

        //[HttpGet("returnTowActions")]
        //public async Task<List<PersonDto>> GetByIdentityCodeAsync(string identityCode)
        //{
        //    var result = GetAsync();
        //    var resulte2 = GetByIdentityCodeAsync(identityCode);
        //    if (identityCode != null)
        //    {
        //        return await resulte2;
        //    }

        //    else
        //    {
                
        //        return await result;
        //    }
        //}

        #endregion
    }
}
