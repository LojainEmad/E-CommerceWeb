using Domain.Exceptions;
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
                //api/Products
                if(httpContext.Response.StatusCode ==StatusCodes.Status404NotFound)
                {
                    var Response = new ErrorToReturn()
                    {
                        StatusCode = httpContext.Response.StatusCode,
                        ErrorMessage =$"End Point{httpContext.Request.Path} is Not Found",
                    };
                    //Return Object as JSON

                    var ResponseToReturn = JsonSerializer.Serialize(Response);

                    await httpContext.Response.WriteAsync(ResponseToReturn);
                }

            }
            catch (Exception ex)
            {
                //Logger
                logger.LogError(ex, "Something Wrong");

                //Response object
                var Response = new ErrorToReturn()
                {
                    //StatusCode = httpContext.Response.StatusCode,
                    ErrorMessage = ex.Message,
                };



                //Set Status Code For Response 

                //httpContext.Response.StatusCode = ex switch
                Response.StatusCode = ex switch
                {
                    NotFoundException =>StatusCodes.Status404NotFound,
                    UnAuthorizedException =>StatusCodes.Status401Unauthorized,
                    BadRequestException  badRequestException=>GetBadRequestErrors(badRequestException , Response),
                    _=> StatusCodes.Status500InternalServerError,
                };

                //Set Content Type for Response
                httpContext.Response.ContentType= "application/json";

                //Return Object as JSON

                var ResponseToReturn =JsonSerializer.Serialize(Response);

                await httpContext.Response.WriteAsync(ResponseToReturn);



            }
            
        }



        private static int GetBadRequestErrors(BadRequestException badRequestException ,ErrorToReturn response)
        {
            response.Errors = badRequestException.Errors;
            return StatusCodes.Status400BadRequest;
        }
       
    }
}
