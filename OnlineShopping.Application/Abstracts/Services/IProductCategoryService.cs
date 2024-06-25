using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.ProductCategory;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Abstracts.Services
{
    [ScopedService]
    public interface IProductCategoryService
    {
        Task<OperationResult> CreateAsync(CreateOrUpdateProductCategory input);

        Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductCategory input);

        Task<ProductCategoryDto> GetAsync(Guid id);

        Task<List<ProductCategoryDto>> GetListAsync();

        Task<OperationResult> UpdateMetaDescriptionAsync(Guid id, CreateOrUpdateProductCategory input);

        List<ProductCategoryDto> GetList();

        Task<OperationResult> RemoveAsync(Guid id);

        Task<int> GetCountProductCategoryAsync();
    }
}
