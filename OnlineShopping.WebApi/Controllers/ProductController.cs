using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Contract;

namespace OnlineShopping.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        #region [-ctor-]
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        #endregion

        #region [-UpdateProductCodeAsync(Guid id, string code)-]
        [HttpPatch("product-code/{id}")]
        public async Task<OperationResult> UpdateProductCodeAsync(Guid id, string code)
        {
            return await productService.UpdateProductCodeAsync(id, code);
        } 
        #endregion
    }
}
