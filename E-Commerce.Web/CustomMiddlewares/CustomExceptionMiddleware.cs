using Microsoft.Extensions.Logging;
using Shared.ErrorModels;
using System.Diagnostics;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace E_Commerce.Web.CustomMiddlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<CustomExceptionMiddleware> logger;

        public CustomExceptionMiddleware(RequestDelegate Next, ILogger<CustomExceptionMiddleware> logger)
        {
            next = Next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                //Logger
                logger.LogError(ex, "Something Wrong");

                //Set Status Code For Response 

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                //Set Content Type for Response
                httpContext.Response.ContentType= "application/json";
                //Response object
                var Response = new ErrorToReturn()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = ex.Message,
                };
                //Return Object as JSON

                var ResponseToReturn =JsonSerializer.Serialize(Response);

                await httpContext.Response.WriteAsync(ResponseToReturn);



            }
            
        }
    }
}
