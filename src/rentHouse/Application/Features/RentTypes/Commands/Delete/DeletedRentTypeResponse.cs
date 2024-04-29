using NArchitecture.Core.Application.Responses;

namespace Application.Features.RentTypes.Commands.Delete;

public class DeletedRentTypeResponse : IResponse
{
    public int Id { get; set; }
}