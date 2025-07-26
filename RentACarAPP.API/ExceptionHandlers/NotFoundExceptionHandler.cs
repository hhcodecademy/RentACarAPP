using Microsoft.AspNetCore.Diagnostics;
using RentACarAPP.Application.Exceptions;
using RentACarAPP.Contract.Dtos;

namespace RentACarAPP.API.ExceptionHandlers
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<NotFoundExceptionHandler> _logger;
        // private readonly IGenericService<LogData, LogDataDTO> _logDataService;

        public NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger)
        {
            _logger = logger;
            //    _logDataService = service;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NotFoundException notFoundException)
            {
                return false;
            }
            _logger.LogError(
                notFoundException,
                "Exception occurred: {Message}",
                notFoundException.Message);
            var logData = new LogDataDTO
            {
                Message = notFoundException.Message,
                Level = Domain.Enum.LogLevel.Error,
                Source = httpContext.Request.Path,
                RequestId = httpContext.TraceIdentifier,

            };

            return true;
        }
    }
}
