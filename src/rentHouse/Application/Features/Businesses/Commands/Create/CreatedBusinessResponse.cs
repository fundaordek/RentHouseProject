using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Businesses.Commands.Create;

public class CreatedBusinessResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string AuthorizedPerson { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public Estate EstateId { get; set; }
    
}