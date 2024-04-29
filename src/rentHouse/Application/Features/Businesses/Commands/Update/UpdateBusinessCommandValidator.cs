using FluentValidation;

namespace Application.Features.Businesses.Commands.Update;

public class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommand>
{
    public UpdateBusinessCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.AuthorizedPerson).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
    }
}