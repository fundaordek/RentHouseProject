using Application.Features.RentTypes.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RentTypes;

public class RentTypeManager : IRentTypeService
{
    private readonly IRentTypeRepository _rentTypeRepository;
    private readonly RentTypeBusinessRules _rentTypeBusinessRules;

    public RentTypeManager(IRentTypeRepository rentTypeRepository, RentTypeBusinessRules rentTypeBusinessRules)
    {
        _rentTypeRepository = rentTypeRepository;
        _rentTypeBusinessRules = rentTypeBusinessRules;
    }

    public async Task<RentType?> GetAsync(
        Expression<Func<RentType, bool>> predicate,
        Func<IQueryable<RentType>, IIncludableQueryable<RentType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RentType? rentType = await _rentTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return rentType;
    }

    public async Task<RentType> AddAsync(RentType rentType)
    {
        RentType addedRentType = await _rentTypeRepository.AddAsync(rentType);

        return addedRentType;
    }

    public async Task<RentType> UpdateAsync(RentType rentType)
    {
        RentType updatedRentType = await _rentTypeRepository.UpdateAsync(rentType);

        return updatedRentType;
    }

    public async Task<RentType> DeleteAsync(RentType rentType, bool permanent = false)
    {
        RentType deletedRentType = await _rentTypeRepository.DeleteAsync(rentType);

        return deletedRentType;
    }
}
