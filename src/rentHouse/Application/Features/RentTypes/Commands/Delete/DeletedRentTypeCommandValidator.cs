using FluentValidation;

namespace Application.Features.RentTypes.Commands.Delete;

public class DeleteRentTypeCommandValidator : AbstractValidator<DeleteRentTypeCommand>
{
    public DeleteRentTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}