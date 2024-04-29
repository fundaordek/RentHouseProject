using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rentals.Queries.GetById;

public class GetByIdRentalResponse : IResponse
{
    public Guid Id { get; set; }
    public int CustomerId { get; set; }
    public int EstateId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime RentalEndDate { get; set; }
}