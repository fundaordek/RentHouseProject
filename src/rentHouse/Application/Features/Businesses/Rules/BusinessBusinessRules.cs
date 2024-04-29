using Application.Features.Businesses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Businesses.Rules;

public class BusinessBusinessRules : BaseBusinessRules
{
    private readonly IBusinessRepository _businessRepository;
    private readonly ILocalizationService _localizationService;

    public BusinessBusinessRules(IBusinessRepository businessRepository, ILocalizationService localizationService)
    {
        _businessRepository = businessRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, BusinessesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task BusinessShouldExistWhenSelected(Business? business)
    {
        if (business == null)
            await throwBusinessException(BusinessesBusinessMessages.BusinessNotExists);
    }

    public async Task BusinessIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Business? business = await _businessRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BusinessShouldExistWhenSelected(business);
    }
}