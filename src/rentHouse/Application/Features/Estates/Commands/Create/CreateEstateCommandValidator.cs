using FluentValidation;

namespace Application.Features.Estates.Commands.Create;

public class CreateEstateCommandValidator : AbstractValidator<CreateEstateCommand>
{
    public CreateEstateCommandValidator()
    {
        RuleFor(c => c.Area).NotEmpty();
        RuleFor(c => c.RoomCount).NotEmpty();
        RuleFor(c => c.Floor).NotEmpty();
        RuleFor(c => c.BuildingFloor).NotEmpty();
        RuleFor(c => c.HeatingType).NotEmpty();
        RuleFor(c=> c.BusinessId).NotEmpty();
        RuleFor(c => c.RentTypeId).NotEmpty();
        RuleFor(c=>c.CustomerId).NotEmpty();
    }
}