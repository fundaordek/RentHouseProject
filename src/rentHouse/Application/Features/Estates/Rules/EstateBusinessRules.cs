using Application.Features.Estates.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Estates.Rules;

public class EstateBusinessRules : BaseBusinessRules
{
    private readonly IEstateRepository _estateRepository;
    private readonly ILocalizationService _localizationService;

    public EstateBusinessRules(IEstateRepository estateRepository, ILocalizationService localizationService)
    {
        _estateRepository = estateRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EstatesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EstateShouldExistWhenSelected(Estate? estate)
    {
        if (estate == null)
            await throwBusinessException(EstatesBusinessMessages.EstateNotExists);
    }

    public async Task EstateIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Estate? estate = await _estateRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EstateShouldExistWhenSelected(estate);
    }
}