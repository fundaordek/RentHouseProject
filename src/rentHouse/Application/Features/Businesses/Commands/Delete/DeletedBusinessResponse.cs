using NArchitecture.Core.Application.Responses;

namespace Application.Features.Businesses.Commands.Delete;

public class DeletedBusinessResponse : IResponse
{
    public Guid Id { get; set; }
}