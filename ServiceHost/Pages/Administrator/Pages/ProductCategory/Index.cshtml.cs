using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Dtos.ProductCategory;

namespace ServiceHost.Pages.Administrator.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryDto> productCategories;
        private readonly IProductCategoryService productCategoryService;

        public IndexModel(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        public void OnGet()
        {
            productCategoryService.GetListAsync();
        }
    }
}
