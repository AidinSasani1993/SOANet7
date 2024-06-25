using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebApi.HttpFilters
{
    public class MyHttpsAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.IsHttps)
            {
                context.Result = new StatusCodeResult(NewStatusCodes.Status520Aidin_Sasani_1993);
            }
        }
    }
    {
    }
}
