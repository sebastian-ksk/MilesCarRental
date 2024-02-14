using MilesCarRental.API.Utils;
using MilesCarRental.BLL.Exceptions;
using MilesCarRental.DAL.Exceptions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MilesCarRental.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var errors = new List<string>();

            switch (exception)
            {
                case BusinessException businessException:
                    code = HttpStatusCode.BadRequest;
                    errors.Add(businessException.Message);
                    break;
                case DataAccessException dataAccessException:
                    code = HttpStatusCode.InternalServerError;
                    errors.Add(dataAccessException.Message);
                    break;
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    errors.Add(validationException.Message);
                    break;
                default:
                    errors.Add("An unexpected error occurred.");
                    break;
            }

            var response = new ApiResponse<object>(false, "An error occurred", null, errors);

            var result = JsonConvert.SerializeObject(response);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
