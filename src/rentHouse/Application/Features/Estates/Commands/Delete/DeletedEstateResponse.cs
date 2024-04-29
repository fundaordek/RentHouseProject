using NArchitecture.Core.Application.Responses;

namespace Application.Features.Estates.Commands.Delete;

public class DeletedEstateResponse : IResponse
{
    public Guid Id { get; set; }
}