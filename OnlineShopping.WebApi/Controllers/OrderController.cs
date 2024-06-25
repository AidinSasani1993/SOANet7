using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Application.Abstracts.Services;

namespace OnlineShopping.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        #region [-ctor-]
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        #endregion

        #region [-GetCountOrdersAsync()-]
        [HttpGet("countAll")]
        public async Task<int> GetCountOrdersAsync()
        {
            return await orderService.GetCountOrdersAsync();
        } 
        #endregion
    }
}
