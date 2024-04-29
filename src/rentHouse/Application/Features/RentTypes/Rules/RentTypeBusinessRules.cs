using Application.Features.RentTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RentTypes.Rules;

public class RentTypeBusinessRules : BaseBusinessRules
{
    private readonly IRentTypeRepository _rentTypeRepository;
    private readonly ILocalizationService _localizationService;

    public RentTypeBusinessRules(IRentTypeRepository rentTypeRepository, ILocalizationService localizationService)
    {
        _rentTypeRepository = rentTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RentTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RentTypeShouldExistWhenSelected(RentType? rentType)
    {
        if (rentType == null)
            await throwBusinessException(RentTypesBusinessMessages.RentTypeNotExists);
    }

    public async Task RentTypeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        RentType? rentType = await _rentTypeRepository.GetAsync(
            predicate: rt => rt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RentTypeShouldExistWhenSelected(rentType);
    }
}