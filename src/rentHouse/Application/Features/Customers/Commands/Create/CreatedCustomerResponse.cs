using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Commands.Create;

public class CreatedCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HomePhone { get; set; }
    public string CellPhone { get; set; }
    public string Email { get; set; }
}