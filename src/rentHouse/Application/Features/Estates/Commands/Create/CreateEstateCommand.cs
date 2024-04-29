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

namespace Application.Features.Estates.Commands.Create;

public class CreateEstateCommand : IRequest<CreatedEstateResponse>,  ILoggableRequest, ITransactionalRequest
{
    public double Area { get; set; }
    public int RoomCount { get; set; }
    public int Floor { get; set; }
    public int BuildingFloor { get; set; }
    public string HeatingType { get; set; }
    public int RentTypeId { get; set; }
    public Guid BusinessId { get; set; }
    public Guid CustomerId { get; set; }
    public class CreateEstateCommandHandler : IRequestHandler<CreateEstateCommand, CreatedEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateRepository _estateRepository;
        private readonly EstateBusinessRules _estateBusinessRules;

        public CreateEstateCommandHandler(IMapper mapper, IEstateRepository estateRepository,
                                         EstateBusinessRules estateBusinessRules)
        {
            _mapper = mapper;
            _estateRepository = estateRepository;
            _estateBusinessRules = estateBusinessRules;
        }

        public async Task<CreatedEstateResponse> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            Estate estate = _mapper.Map<Estate>(request);

            await _estateRepository.AddAsync(estate);

            CreatedEstateResponse response = _mapper.Map<CreatedEstateResponse>(estate);
            return response;
        }
    }
}