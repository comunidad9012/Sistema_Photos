
using ApplicationsServices.Exceptions;
using ApplicationsServices.Wrappers;
using System.Text.Json;

namespace InstituteWebApi.Middlewares
{
    public class ErrorHandlerMiddlerware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddlerware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception err)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>();

                responseModel = new Response<string>() { Successful = false, Message = err?.Message };


                switch (err)
                {
                    case ApiException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case ValidationExceptions e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
