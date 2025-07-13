using Microsoft.AspNetCore.Diagnostics;
using RentACarAPP.Application.Exceptions;

namespace RentACarAPP.API.ExceptionHandlers
{
    public class BadRequestExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<BadRequestExceptionHandler> _logger;

        public BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not BadRequestException badRequestException)
            {
                return false;
            }

            _logger.LogError(
                badRequestException,
                "Exception occurred: {Message}",
                badRequestException.Message);

            return true;
        }
    }
}
