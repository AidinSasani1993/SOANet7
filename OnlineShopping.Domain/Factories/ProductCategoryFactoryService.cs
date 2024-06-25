using OnlineShopping.Domain.Entities;
using OnlineShopping.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Domain.Factories
{
    [ScopedService]
    public class ProductCategoryFactoryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        #region [-ctor-]
        public ProductCategoryFactoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        } 
        #endregion

        #region [-CreateAsync(string name, string description)-]
        public async Task<ProductCategory> CreateAsync(string name, string description)
        {
            var existingProductCategory = await productCategoryRepository.GetByNameAsync(name);
            if (existingProductCategory == null)
            {
                return new ProductCategory(name, description);
            }
            else
            {
                return null;
            }
        } 
        #endregion
    }
}
