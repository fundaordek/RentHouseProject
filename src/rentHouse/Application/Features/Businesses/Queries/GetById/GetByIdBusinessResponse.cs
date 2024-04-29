using NArchitecture.Core.Application.Responses;

namespace Application.Features.Businesses.Queries.GetById;

public class GetByIdBusinessResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string AuthorizedPerson { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}