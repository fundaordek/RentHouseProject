using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentTypes.Commands.Create;

public class CreatedRentTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}