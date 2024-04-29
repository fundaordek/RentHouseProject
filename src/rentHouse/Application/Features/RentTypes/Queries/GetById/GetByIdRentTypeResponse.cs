using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentTypes.Queries.GetById;

public class GetByIdRentTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}