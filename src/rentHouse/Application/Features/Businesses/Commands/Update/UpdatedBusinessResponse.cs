using NArchitecture.Core.Application.Responses;

namespace Application.Features.Businesses.Commands.Update;

public class UpdatedBusinessResponse : IResponse
{
    public string Name { get; set; }
    public string AuthorizedPerson { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}