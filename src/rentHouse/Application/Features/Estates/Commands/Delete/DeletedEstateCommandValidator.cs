using FluentValidation;

namespace Application.Features.Estates.Commands.Delete;

public class DeleteEstateCommandValidator : AbstractValidator<DeleteEstateCommand>
{
    public DeleteEstateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}