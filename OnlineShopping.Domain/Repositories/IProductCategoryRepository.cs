using OnlineShopping.Domain.Contract.Abstracts;
using OnlineShopping.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Repositories
{
    [ScopedService]
    public interface IProductCategoryRepository : IRepository<ProductCategory, Guid>
    {
        Task<string> GetSlugById(Guid id);
        Task<ProductCategory> GetByNameAsync(string name);
        Task<int> GetCountProductCategoryAsync();
    }
}
