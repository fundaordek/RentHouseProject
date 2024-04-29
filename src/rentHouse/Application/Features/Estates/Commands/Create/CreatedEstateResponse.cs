using NArchitecture.Core.Application.Responses;

namespace Application.Features.Estates.Commands.Create;

public class CreatedEstateResponse : IResponse
{
    public Guid Id { get; set; }
    public double Area { get; set; }
    public int RoomCount { get; set; }
    public int Floor { get; set; }
    public int BuildingFloor { get; set; }
    public string HeatingType { get; set; }
    public int RentTypeId { get; set; }
    public Guid BusinessId { get; set; }
    public Guid CustomerId { get; set; }
}