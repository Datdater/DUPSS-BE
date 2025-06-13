using DUPSS.Domain.Exceptions;

namespace DUPSS.API.Middlewares
{
    public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                detail = exception.Message,
                errors = GetErrors(exception),
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(response);
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                InvalidOperationException => StatusCodes.Status400BadRequest,
                Application.Exceptions.ValidationException =>
                    StatusCodes.Status422UnprocessableEntity,
                FormatException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError,
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                DomainException appDomainException => appDomainException.Title,
                _ => "Internal Server Error",
            };

        private static IReadOnlyCollection<Application.Exceptions.ValidationError>? GetErrors(
            Exception exception
        )
        {
            IReadOnlyCollection<Application.Exceptions.ValidationError>? errors = null;
            if (exception is Application.Exceptions.ValidationException validationException)
            {
                errors = validationException.Errors;
            }
            return errors;
        }
    }
}
