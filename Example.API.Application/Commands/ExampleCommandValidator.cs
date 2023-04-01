using FluentValidation;

namespace Example.API.Application.Commands;

public class ExampleCommandValidator : AbstractValidator<ExampleCommand>
{
    public ExampleCommandValidator()
    {
        RuleFor(x => x.EntityId)
            .NotEmpty();
        RuleFor(x => x.EntityName)
            .NotEmpty();
    }
}
