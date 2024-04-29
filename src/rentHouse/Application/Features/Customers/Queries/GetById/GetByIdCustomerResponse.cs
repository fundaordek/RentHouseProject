using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HomePhone { get; set; }
    public string CellPhone { get; set; }
    public string Email { get; set; }
}