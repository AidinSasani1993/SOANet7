﻿using OnlineShopping.Domain.Contract.Abstracts;
using OnlineShopping.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Repositories
{
    [ScopedService]
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
        Task<int> GetCountCustomersAsync();
        Task<int> GetCountOrderOfCustomerAsync();
    }
}
