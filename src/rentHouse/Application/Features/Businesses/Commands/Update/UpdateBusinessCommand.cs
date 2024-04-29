using Application.Features.Businesses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Businesses.Commands.Update;

public class UpdateBusinessCommand : IRequest<UpdatedBusinessResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string AuthorizedPerson { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }

    public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand, UpdatedBusinessResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBusinessRepository _businessRepository;
        private readonly BusinessBusinessRules _businessBusinessRules;

        public UpdateBusinessCommandHandler(IMapper mapper, IBusinessRepository businessRepository,
                                         BusinessBusinessRules businessBusinessRules)
        {
            _mapper = mapper;
            _businessRepository = businessRepository;
            _businessBusinessRules = businessBusinessRules;
        }

        public async Task<UpdatedBusinessResponse> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
        {
            Business? business = await _businessRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _businessBusinessRules.BusinessShouldExistWhenSelected(business);
            business = _mapper.Map(request, business);

            await _businessRepository.UpdateAsync(business!);

            UpdatedBusinessResponse response = _mapper.Map<UpdatedBusinessResponse>(business);
            return response;
        }
    }
}