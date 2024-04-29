using FluentValidation;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.EstateId).NotEmpty();
        RuleFor(c => c.RentalDate).NotEmpty();
        RuleFor(c => c.RentalEndDate).NotEmpty();
    }
}