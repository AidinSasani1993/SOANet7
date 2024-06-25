using AutoMapper;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Contract;
using OnlineShopping.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopping.Application.Services
{
    [ScopedService]
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        #region [-ctor-]
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-UpdateProductCodeAsync(Guid id, UpdateProductCode input)-]
        public async Task<OperationResult> UpdateProductCodeAsync(Guid id, string code)
        {
            var operation = new OperationResult();
            var product = await productRepository.GetByIdAsync(id);

            if (await productRepository.Exists(a => a.Id != id))
            {
                return operation.NotFound(ApplicationMessages.RecordNotFound);
            }

            product.ModifyProductCode(code);
            await productRepository.SaveChangesAsync();

            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
