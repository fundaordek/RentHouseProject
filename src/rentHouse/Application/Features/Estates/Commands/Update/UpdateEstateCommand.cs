using Application.Features.Estates.Constants;
using Application.Features.Estates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Estates.Constants.EstatesOperationClaims;

namespace Application.Features.Estates.Commands.Update;

public class UpdateEstateCommand : IRequest<UpdatedEstateResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public double Area { get; set; }
    public int RoomCount { get; set; }
    public int Floor { get; set; }
    public int BuildingFloor { get; set; }
    public string HeatingType { get; set; }
    public int RentTypeId { get; set; }
    public Guid BusinessId { get; set; }
    public Guid CustomerId { get; set; }

    public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateCommand, UpdatedEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateRepository _estateRepository;
        private readonly EstateBusinessRules _estateBusinessRules;

        public UpdateEstateCommandHandler(IMapper mapper, IEstateRepository estateRepository,
                                         EstateBusinessRules estateBusinessRules)
        {
            _mapper = mapper;
            _estateRepository = estateRepository;
            _estateBusinessRules = estateBusinessRules;
        }

        public async Task<UpdatedEstateResponse> Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            Estate? estate = await _estateRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _estateBusinessRules.EstateShouldExistWhenSelected(estate);
            estate = _mapper.Map(request, estate);

            await _estateRepository.UpdateAsync(estate!);

            UpdatedEstateResponse response = _mapper.Map<UpdatedEstateResponse>(estate);
            return response;
        }
    }
}