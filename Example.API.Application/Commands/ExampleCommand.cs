using MediatR;

namespace Example.API.Application.Commands;

public class ExampleCommand : IRequest<string>
{
    public Guid EntityId { get; private set; }
    public string EntityName { get; private set; }

    public ExampleCommand(Guid entityId, string entityName)
    {
        EntityId = entityId;
        EntityName = entityName;
    }
}