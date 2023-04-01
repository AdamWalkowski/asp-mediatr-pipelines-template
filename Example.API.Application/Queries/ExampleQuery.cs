using MediatR;

namespace Example.API.Application.Queries;

public class ExampleQuery : IRequest<SampleEntity>
{
    public Guid Id { get; private set; }

    public ExampleQuery(Guid id)
    {
        Id = id;
    }
}
