using AutoMapper;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.Customer;
using OnlineShopping.Application.Dtos.Person;
using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using System.Linq;

namespace OnlineShopping.Application.Services
{
    [ScopedService]
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        #region [-ctor-]
        public CustomerService(ICustomerRepository customerRepository,
                               IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-Tasks-]

        #region [-GetCountCustomersAsync()-]
        public async Task<int> GetCountCustomersAsync()
        {
            var count = await customerRepository.GetCountCustomersAsync();
            return count;
        }
        #endregion

        #region [-GetCountOrderOfCustomerAsync()-]
        public async Task<int> GetCountOrderOfCustomerAsync()
        {
            return await customerRepository.GetCountOrderOfCustomerAsync();
        }
        #endregion

        #region [-CreateCustomerAsync(CreateOrUpdateCustomerInput input)-]
        public async Task<OperationResult> CreateCustomerAsync(CreateOrUpdateCustomerInput input)
        {
            var operation = new OperationResult();

            if (await customerRepository.Exists(a => a.Code == input.Code))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }

            var customer = new Customer(input.PersonRef, input.Code);

            await customerRepository.InsertAsync(customer);

            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #region [-UpdateCustomerAsync(Guid id, UpdateCustomerDto input)-]
        public async Task<OperationResult> UpdateCustomerAsync(Guid id, UpdateCustomerDto input)
        {
            var operation = new OperationResult();
            var customer = await customerRepository.GetByIdAsync(id);

            customer.Modify(input.Code);
            await customerRepository.UpdateAsync(customer);
            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #region [-GetAllRecordAsync()-]
        public async Task<List<CustomerDto>> GetAllRecordAsync()
        {
            var query = await customerRepository.GetAllAsync();
            return mapper.Map<List<CustomerDto>>(query);
        }
        #endregion

        #region [-DeleteAsync(Guid id)-]
        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            var operation = new OperationResult();
            var customer = await customerRepository.GetByIdAsync(id);

            customer.Remove();
            await customerRepository.SaveChangesAsync();
            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #region [-ActiveAsync(Guid id)-]
        public async Task<OperationResult> ActiveAsync(Guid id)
        {
            var operation = new OperationResult();
            var customer = await customerRepository.GetByIdAsync(id);

            customer.Active();
            await customerRepository.SaveChangesAsync();
            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #endregion
    }
}
