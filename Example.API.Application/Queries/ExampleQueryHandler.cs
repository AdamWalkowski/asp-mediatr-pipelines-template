using MediatR;

namespace Example.API.Application.Queries;

public class ExampleQueryHandler : IRequestHandler<ExampleQuery, SampleEntity>
{
    public Task<SampleEntity> Handle(ExampleQuery query, CancellationToken cancellationToken)
    {
        return Task.FromResult(new SampleEntity(query.Id, "test name"));
    }
}
