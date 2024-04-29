using Application.Features.Businesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Businesses.Queries.GetById;

public class GetByIdBusinessQuery : IRequest<GetByIdBusinessResponse>
{
    public Guid Id { get; set; }

    public class GetByIdBusinessQueryHandler : IRequestHandler<GetByIdBusinessQuery, GetByIdBusinessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        private readonly BusinessBusinessRules _businessBusinessRules;

        public GetByIdBusinessQueryHandler(IMapper mapper, IBusinessRepository businessRepository, BusinessBusinessRules businessBusinessRules)
        {
            _mapper = mapper;
            _businessRepository = businessRepository;
            _businessBusinessRules = businessBusinessRules;
        }

        public async Task<GetByIdBusinessResponse> Handle(GetByIdBusinessQuery request, CancellationToken cancellationToken)
        {
            Business? business = await _businessRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _businessBusinessRules.BusinessShouldExistWhenSelected(business);

            GetByIdBusinessResponse response = _mapper.Map<GetByIdBusinessResponse>(business);
            return response;
        }
    }
}