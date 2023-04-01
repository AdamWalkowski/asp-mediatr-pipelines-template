using Microsoft.AspNetCore.Mvc.Filters;

namespace Example.API.Web.Filters;

public class AsyncActionFilter : IAsyncActionFilter
{
    private readonly ILogger<SampleActionFilter> _logger;

    public AsyncActionFilter(ILogger<SampleActionFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.LogInformation($"Async action execution for '{nameof(context)}' {context.Controller.ToString()}");
        await next();
    }
}
