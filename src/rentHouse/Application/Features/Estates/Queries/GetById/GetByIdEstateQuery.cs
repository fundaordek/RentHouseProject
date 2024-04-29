using Application.Features.Estates.Constants;
using Application.Features.Estates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Estates.Queries.GetById;

public class GetByIdEstateQuery : IRequest<GetByIdEstateResponse>
{
    public Guid Id { get; set; }

    public class GetByIdEstateQueryHandler : IRequestHandler<GetByIdEstateQuery, GetByIdEstateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEstateRepository _estateRepository;
        private readonly EstateBusinessRules _estateBusinessRules;

        public GetByIdEstateQueryHandler(IMapper mapper, IEstateRepository estateRepository, EstateBusinessRules estateBusinessRules)
        {
            _mapper = mapper;
            _estateRepository = estateRepository;
            _estateBusinessRules = estateBusinessRules;
        }

        public async Task<GetByIdEstateResponse> Handle(GetByIdEstateQuery request, CancellationToken cancellationToken)
        {
            Estate? estate = await _estateRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _estateBusinessRules.EstateShouldExistWhenSelected(estate);

            GetByIdEstateResponse response = _mapper.Map<GetByIdEstateResponse>(estate);
            return response;
        }
    }
}