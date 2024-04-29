using FluentValidation;

namespace Application.Features.RentTypes.Commands.Update;

public class UpdateRentTypeCommandValidator : AbstractValidator<UpdateRentTypeCommand>
{
    public UpdateRentTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}