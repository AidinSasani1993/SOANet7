using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineShopping.Application.Abstracts.Services;
using OnlineShopping.Application.Dtos.ProductCategory;

namespace ServiceHost.Pages
{
    public class Index1Model : PageModel
    {
        public List<ProductCategoryDto> ListModel;
        private readonly IProductCategoryService productCategoryService;

        public Index1Model(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        public void OnGetProductCategory()
        {
            ListModel = productCategoryService.GetList();
        }
    }
}
