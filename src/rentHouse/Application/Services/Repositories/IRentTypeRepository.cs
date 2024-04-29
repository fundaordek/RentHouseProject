using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRentTypeRepository : IAsyncRepository<RentType, int>, IRepository<RentType, int>
{
}