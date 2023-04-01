using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Example.API.Application.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;
    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Processing '{typeof(TRequest).Name}' request");

        IList<PropertyInfo> properties = new List<PropertyInfo>(request.GetType().GetProperties());
        properties.ToList().ForEach(prop =>
        {
            _logger.LogInformation($"{prop.Name} : {prop.GetValue(request, null)}");
        });

        return await next();
    }
}
