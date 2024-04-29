using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RentTypeRepository : EfRepositoryBase<RentType, int, BaseDbContext>, IRentTypeRepository
{
    public RentTypeRepository(BaseDbContext context) : base(context)
    {
    }
}