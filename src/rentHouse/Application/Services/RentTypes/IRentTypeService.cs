using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RentTypes;

public interface IRentTypeService
{
    Task<RentType?> GetAsync(
        Expression<Func<RentType, bool>> predicate,
        Func<IQueryable<RentType>, IIncludableQueryable<RentType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RentType> AddAsync(RentType rentType);
    Task<RentType> UpdateAsync(RentType rentType);
    Task<RentType> DeleteAsync(RentType rentType, bool permanent = false);
}
