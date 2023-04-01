using FluentValidation;

namespace Example.API.Application.Queries;

public class ExampleQueryValidator : AbstractValidator<ExampleQuery>
{
    public ExampleQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}
