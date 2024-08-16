using Application.Common.Models;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "Evoltis test Api Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
            var response = new ResponseObjectJsonDto();

            if (ex is ValidationException) {

                response.Response = null;
                response.StatusCode = 400;
                response.Message = ex.Message;
            }

            else
            {
                response.Response = null;
                response.StatusCode = 500;
                response.Message = ex.Message;
            }

            if (typeof(TResponse) == typeof(ResponseObjectJsonDto))
            {
                return (TResponse)(object)response;
            }

            throw;
        }
    }
}