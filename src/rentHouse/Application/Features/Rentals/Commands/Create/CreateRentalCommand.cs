using Application.Features.Rentals.Constants;
using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Rentals.Constants.RentalsOperationClaims;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommand : IRequest<CreatedRentalResponse>, ILoggableRequest, ITransactionalRequest
{
    public Guid CustomerId { get; set; }
    public Guid EstateId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime RentalEndDate { get; set; }

    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreatedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public CreateRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
                                         RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<CreatedRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            Rental rental = _mapper.Map<Rental>(request);

            await _rentalRepository.AddAsync(rental);

            CreatedRentalResponse response = _mapper.Map<CreatedRentalResponse>(rental);
            return response;
        }
    }
}