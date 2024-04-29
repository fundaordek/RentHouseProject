using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Estates;

public interface IEstateService
{
    Task<Estate?> GetAsync(
        Expression<Func<Estate, bool>> predicate,
        Func<IQueryable<Estate>, IIncludableQueryable<Estate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Estate> AddAsync(Estate estate);
    Task<Estate> UpdateAsync(Estate estate);
    Task<Estate> DeleteAsync(Estate estate, bool permanent = false);
}
