using Application.Features.Estates.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Estates;

public class EstateManager : IEstateService
{
    private readonly IEstateRepository _estateRepository;
    private readonly EstateBusinessRules _estateBusinessRules;

    public EstateManager(IEstateRepository estateRepository, EstateBusinessRules estateBusinessRules)
    {
        _estateRepository = estateRepository;
        _estateBusinessRules = estateBusinessRules;
    }

    public async Task<Estate?> GetAsync(
        Expression<Func<Estate, bool>> predicate,
        Func<IQueryable<Estate>, IIncludableQueryable<Estate, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Estate? estate = await _estateRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return estate;
    }

    public async Task<Estate> AddAsync(Estate estate)
    {
        Estate addedEstate = await _estateRepository.AddAsync(estate);

        return addedEstate;
    }

    public async Task<Estate> UpdateAsync(Estate estate)
    {
        Estate updatedEstate = await _estateRepository.UpdateAsync(estate);

        return updatedEstate;
    }

    public async Task<Estate> DeleteAsync(Estate estate, bool permanent = false)
    {
        Estate deletedEstate = await _estateRepository.DeleteAsync(estate);

        return deletedEstate;
    }
}
