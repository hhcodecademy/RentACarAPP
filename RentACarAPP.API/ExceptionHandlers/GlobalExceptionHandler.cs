using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RentACarAPP.API.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<BadRequestExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<BadRequestExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);

           


            return true;
        }
    }
}
