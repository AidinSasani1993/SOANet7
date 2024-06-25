using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Contract;
using OnlineShopping.Application.Dtos.ProductCategory;

namespace OnlineShopping.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [HttpGet("productCategory")]
        public async Task<List<ProductCategoryDto>> GetAllAsync()
        {
            return await productCategoryService.GetListAsync();
        }

        [HttpGet("productCategory/{id}")]
        public async Task<ProductCategoryDto> GetAsync(Guid id)
        {
            return await productCategoryService.GetAsync(id);
        }

        [HttpPost("productCategory")]
        public async Task<OperationResult> CreateProductCategoryAsync(CreateOrUpdateProductCategory input)
        {
            return await productCategoryService.CreateAsync(input);
        }

        [HttpPut("productCategory")]
        public async Task<OperationResult> UpdateProductCategoryAsync(Guid id, CreateOrUpdateProductCategory input)
        {
            return await productCategoryService.UpdateAsync(id, input);
        }

        [HttpDelete("productCategory/{id}")]
        public async Task DeleteProductCategoryAsync(Guid id)
        {
            await productCategoryService.RemoveAsync(id);
        }

        [HttpPatch("productCategory-metaDesription/{id}")]
        public async Task UpdateMetaDescriptionAsync(Guid id, CreateOrUpdateProductCategory input)
        {
            await productCategoryService.UpdateMetaDescriptionAsync(id, input);
        }

        [HttpGet("countCountProductCategory")]
        public async Task<int> GetCountProductCategoryAsync()
        {
            return await productCategoryService.GetCountProductCategoryAsync();
        }
    }
}
