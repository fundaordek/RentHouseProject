using Application.Features.RentTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RentTypes.Queries.GetById;

public class GetByIdRentTypeQuery : IRequest<GetByIdRentTypeResponse>
{
    public int Id { get; set; }

    public class GetByIdRentTypeQueryHandler : IRequestHandler<GetByIdRentTypeQuery, GetByIdRentTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentTypeRepository _rentTypeRepository;
        private readonly RentTypeBusinessRules _rentTypeBusinessRules;

        public GetByIdRentTypeQueryHandler(IMapper mapper, IRentTypeRepository rentTypeRepository, RentTypeBusinessRules rentTypeBusinessRules)
        {
            _mapper = mapper;
            _rentTypeRepository = rentTypeRepository;
            _rentTypeBusinessRules = rentTypeBusinessRules;
        }

        public async Task<GetByIdRentTypeResponse> Handle(GetByIdRentTypeQuery request, CancellationToken cancellationToken)
        {
            RentType? rentType = await _rentTypeRepository.GetAsync(predicate: rt => rt.Id == request.Id, cancellationToken: cancellationToken);
            await _rentTypeBusinessRules.RentTypeShouldExistWhenSelected(rentType);

            GetByIdRentTypeResponse response = _mapper.Map<GetByIdRentTypeResponse>(rentType);
            return response;
        }
    }
}