using Application.Features.Businesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Businesses.Commands.Create;

public class CreateBusinessCommand : IRequest<CreatedBusinessResponse>
{
    public string Name { get; set; }
    public string AuthorizedPerson { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, CreatedBusinessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        private readonly BusinessBusinessRules _businessBusinessRules;

        public CreateBusinessCommandHandler(IMapper mapper, IBusinessRepository businessRepository,
                                         BusinessBusinessRules businessBusinessRules)
        {
            _mapper = mapper;
            _businessRepository = businessRepository;
            _businessBusinessRules = businessBusinessRules;
        }

        public async Task<CreatedBusinessResponse> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
        {
            Business business = _mapper.Map<Business>(request);

            await _businessRepository.AddAsync(business);

            CreatedBusinessResponse response = _mapper.Map<CreatedBusinessResponse>(business);
            return response;
        }
    }
}