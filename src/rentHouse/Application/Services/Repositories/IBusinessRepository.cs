using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IBusinessRepository : IAsyncRepository<Business, Guid>, IRepository<Business, Guid>
{
}