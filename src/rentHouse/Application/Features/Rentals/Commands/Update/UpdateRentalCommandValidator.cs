using FluentValidation;

namespace Application.Features.Rentals.Commands.Update;

public class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
{
    public UpdateRentalCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.EstateId).NotEmpty();
        RuleFor(c => c.RentalDate).NotEmpty();
        RuleFor(c => c.RentalEndDate).NotEmpty();
    }
}