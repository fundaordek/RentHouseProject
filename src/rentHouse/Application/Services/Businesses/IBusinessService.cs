using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Businesses;

public interface IBusinessService
{
    Task<Business?> GetAsync(
        Expression<Func<Business, bool>> predicate,
        Func<IQueryable<Business>, IIncludableQueryable<Business, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<Business> AddAsync(Business business);
    Task<Business> UpdateAsync(Business business);
    Task<Business> DeleteAsync(Business business, bool permanent = false);
}
