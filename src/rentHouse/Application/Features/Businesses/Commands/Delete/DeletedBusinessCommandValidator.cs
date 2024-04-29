using FluentValidation;

namespace Application.Features.Businesses.Commands.Delete;

public class DeleteBusinessCommandValidator : AbstractValidator<DeleteBusinessCommand>
{
    public DeleteBusinessCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}