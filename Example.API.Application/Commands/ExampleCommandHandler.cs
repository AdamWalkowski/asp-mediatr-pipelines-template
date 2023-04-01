using MediatR;

namespace Example.API.Application.Commands;

public class ExampleCommandHandler : IRequestHandler<ExampleCommand, string>
{
    public Task<string> Handle(ExampleCommand command, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Hanler ${nameof(command)} invoked!");

        return Task.FromResult("ok");
    }
}
