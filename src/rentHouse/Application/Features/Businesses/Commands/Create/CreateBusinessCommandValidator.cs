using Domain.Entities;
using FluentValidation;

namespace Application.Features.Businesses.Commands.Create;

public class CreateBusinessCommandValidator : AbstractValidator<CreateBusinessCommand>
{
    public CreateBusinessCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AuthorizedPerson).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
    }
}