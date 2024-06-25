using Azure;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.Customer;

namespace OnlineShopping.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        #region [-ctor-]
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        #endregion

        #region [-GetCountCustomersAsync()-]
        [HttpGet("countCustomer")]
        public async Task<int> GetCountCustomersAsync()
        {
            return await customerService.GetCountCustomersAsync();
        }
        #endregion

        #region [-GetCountOrderOfCustomerAsync()-]
        [HttpGet("countOrderOfCustomer")]
        public async Task<int> GetCountOrderOfCustomerAsync()
        {
            return await customerService.GetCountOrderOfCustomerAsync();
        }
        #endregion

        #region [-CreateCustomerAsync(CreateOrUpdateCustomerInput input)-]
        [HttpPost("create")]
        public async Task<OperationResult> CreateCustomerAsync(CreateOrUpdateCustomerInput input)
        {
            return await customerService.CreateCustomerAsync(input);
        }
        #endregion

        #region [-UpdateCustomerAsync(Guid id, UpdateCustomerDto input)-]
        [HttpPatch("update")]
        public async Task<OperationResult> UpdateCustomerAsync(Guid id, UpdateCustomerDto input)
        {
            return await customerService.UpdateCustomerAsync(id, input);
        }
        #endregion

        #region [-GetAllRecordAsync()-]
        [HttpGet("customer")]
        public async Task<List<CustomerDto>> GetAllRecordAsync()
        {
            return await customerService.GetAllRecordAsync();
        }
        #endregion

        #region [-DeleteAsync(Guid id)-]
        [HttpDelete("id")]
        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            return await customerService.DeleteAsync(id);
        }
        #endregion

        #region [-ActiveAsync(Guid id)-]
        [HttpPatch("id/active")]
        public async Task<OperationResult> ActiveAsync(Guid id)
        {
            return await customerService.ActiveAsync(id);
        } 
        #endregion
    }
}
