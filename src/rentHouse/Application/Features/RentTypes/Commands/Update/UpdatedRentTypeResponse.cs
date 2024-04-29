using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentTypes.Commands.Update;

public class UpdatedRentTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}