using FluentValidation;

namespace Application.Features.RentTypes.Commands.Create;

public class CreateRentTypeCommandValidator : AbstractValidator<CreateRentTypeCommand>
{
    public CreateRentTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}