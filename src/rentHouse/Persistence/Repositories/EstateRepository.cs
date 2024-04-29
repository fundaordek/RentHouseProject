using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EstateRepository : EfRepositoryBase<Estate, Guid, BaseDbContext>, IEstateRepository
{
    public EstateRepository(BaseDbContext context) : base(context)
    {
    }
}