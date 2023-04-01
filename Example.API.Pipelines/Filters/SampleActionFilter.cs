using Microsoft.AspNetCore.Mvc.Filters;

namespace Example.API.Web.Filters;

public class SampleActionFilter : IActionFilter
{
    private readonly ILogger<SampleActionFilter> _logger;

    public SampleActionFilter(ILogger<SampleActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($"Method called before action '{context.ActionDescriptor.DisplayName}' {context.Controller.ToString()}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"Action called after action '{context.ActionDescriptor.DisplayName}' {context.Controller.ToString()}");
    }
}
