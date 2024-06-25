using Newtonsoft.Json;
using System.Net;

namespace OnlineShopping.WebApi.Middlewares.ApiExceptionHandler
{
    public class ApiExceptionMiddleware
    {
        #region [-ctor-]
        public ApiExceptionMiddleware()
        {

        }
        #endregion

        #region [-props-]
        public RequestDelegate Next { get; set; }
        public ILogger<ApiExceptionMiddleware> Logger { get; set; }
        #endregion

        #region [-Methods-]

        #region [-Invoke(HttpContext httpContext)-]
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await Next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptioAsync(httpContext, ex);
            }
        }
        #endregion

        #region [-HandleExceptioAsync(HttpContext context, Exception exception)-]
        private Task HandleExceptioAsync(HttpContext context, Exception exception)
        {
            var error = new ApiError
            {
                Id = Guid.NewGuid().ToString(),
                Status = (short)HttpStatusCode.InternalServerError,
                Title = "This Is Error"
            };

            var innerException = GetInnermostExceptionMessag(exception);

            var level = LogLevel.Error;

            Logger.Log(level, exception, "Exception Message Is : " + innerException + "ErrorId.", error.Id);

            var result = JsonConvert.SerializeObject(error);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(result);
        }
        #endregion

        #region [-GetInnermostExceptionMessag(Exception exception)-]
        private string GetInnermostExceptionMessag(Exception exception)
        {
            if (exception.InnerException != null)
            {
                return GetInnermostExceptionMessag(exception.InnerException);
            }
            else
            {
                return exception.Message;
            }
        }
        #endregion

        #endregion
    }
}
