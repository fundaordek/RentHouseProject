using FluentValidation;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.HomePhone).NotEmpty();
        RuleFor(c => c.CellPhone).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
    }
}