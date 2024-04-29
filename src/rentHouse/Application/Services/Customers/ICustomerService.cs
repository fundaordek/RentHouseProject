using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Customers;

public interface ICustomerService
{
    Task<Customer?> GetAsync(
        Expression<Func<Customer, bool>> predicate,
        Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Customer> AddAsync(Customer customer);
    Task<Customer> UpdateAsync(Customer customer);
    Task<Customer> DeleteAsync(Customer customer, bool permanent = false);
}
