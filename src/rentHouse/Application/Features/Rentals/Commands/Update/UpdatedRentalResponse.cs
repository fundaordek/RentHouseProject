using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rentals.Commands.Update;

public class UpdatedRentalResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid EstateId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime RentalEndDate { get; set; }
}