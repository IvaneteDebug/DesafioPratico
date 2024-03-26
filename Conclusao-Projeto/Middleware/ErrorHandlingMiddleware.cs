using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Conclusao_Projeto.Exceptions;

namespace Conclusao_Projeto.Middleware
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
            var code = StatusCodes.Status500InternalServerError;

            if (exception is UserValidationException)
            {
                code = StatusCodes.Status400BadRequest;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = exception.Message }));
        }
    }
}