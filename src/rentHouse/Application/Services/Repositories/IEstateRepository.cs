using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEstateRepository : IAsyncRepository<Estate, Guid>, IRepository<Estate, Guid>
{
}