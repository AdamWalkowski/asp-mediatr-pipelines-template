using Example.API.Application.Commands;
using MediatR;

namespace Example.API.Application.Behaviours;

public class BeforeCommandBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request.GetType() == typeof(ExampleCommand))
        {
            Console.WriteLine($"Pipeline behaviour {nameof(request)} invoked!");
        }
        return await next();
    }
}
