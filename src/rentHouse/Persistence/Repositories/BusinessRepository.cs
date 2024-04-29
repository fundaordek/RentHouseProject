using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class BusinessRepository : EfRepositoryBase<Business, Guid, BaseDbContext>, IBusinessRepository
{
    public BusinessRepository(BaseDbContext context) : base(context)
    {
    }
}