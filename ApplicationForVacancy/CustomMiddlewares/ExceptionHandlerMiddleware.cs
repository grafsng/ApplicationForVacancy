using System;
using System.Net;
using System.Threading.Tasks;
using ApplicationForVacancy.CustomExceptionClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace ApplicationForVacancy.CustomMiddlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);

            var code = ex switch
            {
                NotFoundException _ => HttpStatusCode.NotFound,
                BadRequestException _ => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            //var errors = new List<string> {ex.Message};

            //var result = JsonSerializer.Serialize(ApiResult<string>.Failure((int)code, errors));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(ex.Message);
        }

    }
}
