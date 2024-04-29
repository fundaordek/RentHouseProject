using Application.Features.Businesses.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Businesses;

public class BusinessManager : IBusinessService
{
    private readonly IBusinessRepository _businessRepository;
    private readonly BusinessBusinessRules _businessBusinessRules;

    public BusinessManager(IBusinessRepository businessRepository, BusinessBusinessRules businessBusinessRules)
    {
        _businessRepository = businessRepository;
        _businessBusinessRules = businessBusinessRules;
    }

    public async Task<Business?> GetAsync(
        Expression<Func<Business, bool>> predicate,
        Func<IQueryable<Business>, IIncludableQueryable<Business, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Business? business = await _businessRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return business;
    }


    public async Task<Business> AddAsync(Business business)
    {
        Business addedBusiness = await _businessRepository.AddAsync(business);

        return addedBusiness;
    }

    public async Task<Business> UpdateAsync(Business business)
    {
        Business updatedBusiness = await _businessRepository.UpdateAsync(business);

        return updatedBusiness;
    }

    public async Task<Business> DeleteAsync(Business business, bool permanent = false)
    {
        Business deletedBusiness = await _businessRepository.DeleteAsync(business);

        return deletedBusiness;
    }
}
